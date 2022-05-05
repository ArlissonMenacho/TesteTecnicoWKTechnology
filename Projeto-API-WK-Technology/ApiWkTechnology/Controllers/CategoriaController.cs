using ApiWkTechnology.Service.Interfaces;
using ApiWkTechnology.Service.ViewModels.Categoria;
using Microsoft.AspNetCore.Mvc;

namespace ApiWkTechnology.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServices _categoriaServices;
        public CategoriaController(ICategoriaServices categoriaServices)
        {
            _categoriaServices = categoriaServices;
        }

        [HttpGet("BuscarTodasCategoria")]
        public async Task<IActionResult> BuscarTodos(CancellationToken cancellationToken)
        {
            return Ok(await _categoriaServices.BuscaTodasAsync(cancellationToken));
        }

        [HttpGet("BuscaPorId/{Id}")]
        public async Task<IActionResult> BuscaPorId(Guid Id, CancellationToken cancellationToken)
        {
            return Ok(await _categoriaServices.BuscaPorIdAsync(Id, cancellationToken));
        }

        [HttpPost("CadastrarCategoria")]
        public async Task<IActionResult> CadastrarCategoria(CreateCategoriaViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok(await _categoriaServices.CadastrarCategoriaAsync(viewModel, cancellationToken));
        }

        [HttpPut("AtualizarCategoria")]
        public async Task<IActionResult> AtualizarCategoria(UpdateCategoriaViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok(await _categoriaServices.AtualizarCategoriaAsync(viewModel, cancellationToken));
        }

        [HttpDelete("DeletarCategoria/{Id}")]
        public async Task<IActionResult> DeletarCategoria(Guid Id, CancellationToken cancellationToken)
        {
            await _categoriaServices.DeletarCategoriaAsync(Id, cancellationToken);
            return Ok("Categoria deletada com Sucesso!");
        }
    }
}
