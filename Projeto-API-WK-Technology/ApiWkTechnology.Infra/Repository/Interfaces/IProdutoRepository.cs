using ApiWkTechnology.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWkTechnology.Infra.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> BuscaTodosAsync(CancellationToken cancellationToken);
        Task<Produto> BuscaPorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Produto> CadastrarProdutoAsync(Produto produto, CancellationToken cancellationToken);
        Task<Produto> AtualizarProdutoAsync(Produto produto, CancellationToken cancellationToken);
        Task DeletarProdutoAsync(Guid idProduto, CancellationToken cancellationToken);
    }
}
