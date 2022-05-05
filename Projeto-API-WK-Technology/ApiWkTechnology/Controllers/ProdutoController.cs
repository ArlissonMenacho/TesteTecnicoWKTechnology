using ApiWkTechnology.Service.Interfaces;
using ApiWkTechnology.Service.ViewModels.Produto;
using Microsoft.AspNetCore.Mvc;

namespace ApiWkTechnology.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServices _produtoServices;
        public ProdutoController(IProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;
        }

        [HttpGet("BuscarTodosProdutos")]
        public async Task<IActionResult> BuscarTodosProdutos(CancellationToken cancellationToken)
        {
            return Ok(await _produtoServices.BuscaTodosAsync(cancellationToken));
        }

        [HttpGet("BuscaPorId/{Id}")]
        public async Task<IActionResult> BuscaPorId(Guid Id, CancellationToken cancellationToken)
        {
            return Ok(await _produtoServices.BuscaPorIdAsync(Id, cancellationToken));
        }

        [HttpPost("CadastrarProduto")]
        public async Task<IActionResult> CadastrarProduto(CreateProdutoViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok(await _produtoServices.CadastrarProdutoAsync(viewModel, cancellationToken));
        }

        [HttpPut("AtualizarProduto")]
        public async Task<IActionResult> AtualizarProduto(UpdateProdutoViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok(await _produtoServices.AtualizarProdutoAsync(viewModel, cancellationToken));
        }

        [HttpDelete("DeletarProduto/{Id}")]
        public async Task<IActionResult> DeletarProduto(Guid Id, CancellationToken cancellationToken)
        {
            await _produtoServices.DeletarProdutoAsync(Id, cancellationToken);
            return Ok("Produto deletado com Sucesso!");
        }
    }
}
