using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoWebWkTechnology.Domain.Entities;
using ProjetoWebWkTechnology.Service.Interfaces.APIService;


namespace ProjetoWebWkTechnology.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IProdutoECategoriaAPIService _service;
        public CategoriaController(IProdutoECategoriaAPIService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var resultado = await _service.BuscarTodasCategorias(cancellationToken);
            return View(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> CadastrarCategoria(CancellationToken cancellationToken)
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
        public async Task<IActionResult> CadastrarCategoria(Categoria categoria, CancellationToken cancellationToken)
        {
            await _service.CriarCategoria(categoria, cancellationToken);
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
            var resultado = await _service.BuscarCategoriaPorId(id, cancellationToken);
            return View(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Categoria categoria, CancellationToken cancellationToken)
        {
            await _service.AtualizarCategoria(categoria, cancellationToken);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(Guid id, CancellationToken cancellationToken)
        {
            await _service.DeletarCategoria(id, cancellationToken);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Visualizar(Guid id, CancellationToken cancellationToken)
        {
            var result = await _service.BuscarCategoriaPorId(id, cancellationToken);
            return View(result);
        }
    }
}
