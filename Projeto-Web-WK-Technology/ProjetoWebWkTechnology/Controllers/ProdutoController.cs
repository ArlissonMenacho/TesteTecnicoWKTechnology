using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoWebWkTechnology.Domain.Entities;
using ProjetoWebWkTechnology.Service.Interfaces.APIService;

namespace ProjetoWebWkTechnology.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoECategoriaAPIService _service;
        public ProdutoController(IProdutoECategoriaAPIService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var resultado = await _service.BuscarTodosProdutos(cancellationToken);
            return View(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> CadastrarProduto(CancellationToken cancellationToken)
        {
            var categorias = await _service.BuscarTodasCategorias(cancellationToken);
            var selectList = categorias.Select(c => new SelectListItem
            {
                Text = c.Nome,
                Value = c.Id.ToString()
            });
            ViewBag.categoriasExistentes = new SelectList(selectList, "Value", "Text");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarProduto(Produto produto, CancellationToken cancellationToken)
        {
            await _service.CriarProduto(produto, cancellationToken);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(Guid id, CancellationToken cancellationToken)
        {
            var categorias = await _service.BuscarTodasCategorias(cancellationToken);
            var selectList = categorias.Select(c => new SelectListItem
            {
                Text = c.Nome,
                Value = c.Id.ToString()
            });
            ViewBag.categoriasExistentes = new SelectList(selectList, "Value", "Text");
            var resultado = await _service.BuscarProdutoPorId(id, cancellationToken);
            return View(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Produto produto, CancellationToken cancellationToken)
        {
            await _service.AtualizarProduto(produto, cancellationToken);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(Guid id, CancellationToken cancellationToken)
        {
            await _service.DeletarProduto(id, cancellationToken);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Visualizar(Guid id, CancellationToken cancellationToken)
        {
            var result = await _service.BuscarProdutoPorId(id, cancellationToken);
            return View(result);
        }

    }
}
