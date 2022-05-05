using ProjetoWebWkTechnology.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWebWkTechnology.Service.Interfaces.APIService
{
    public interface IProdutoECategoriaAPIService
    {
        Task<List<Categoria>> BuscarTodasCategorias(CancellationToken cancellationToken);
        Task<Categoria> BuscarCategoriaPorId(Guid id, CancellationToken cancellationToken);
        Task CriarCategoria(Categoria categoria, CancellationToken cancellationToken);
        Task AtualizarCategoria(Categoria categoria, CancellationToken cancellationToken);
        Task DeletarCategoria(Guid id, CancellationToken cancellationToken);
        Task<List<Produto>> BuscarTodosProdutos(CancellationToken cancellationToken);
        Task<Produto> BuscarProdutoPorId(Guid id, CancellationToken cancellationToken);
        Task CriarProduto(Produto produto, CancellationToken cancellationToken);
        Task AtualizarProduto(Produto produto, CancellationToken cancellationToken);
        Task DeletarProduto(Guid id, CancellationToken cancellationToken);

    }
}
