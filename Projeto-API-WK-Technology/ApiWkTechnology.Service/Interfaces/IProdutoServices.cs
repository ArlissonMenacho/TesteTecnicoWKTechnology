using ApiWkTechnology.Domain.Entities;
using ApiWkTechnology.Service.ViewModels;
using ApiWkTechnology.Service.ViewModels.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWkTechnology.Service.Interfaces
{
    public interface IProdutoServices
    {
        Task<List<Produto>> BuscaTodosAsync(CancellationToken cancellationToken);
        Task<Produto> BuscaPorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Produto> CadastrarProdutoAsync(CreateProdutoViewModel viewModel, CancellationToken cancellationToken);
        Task<Produto> AtualizarProdutoAsync(UpdateProdutoViewModel viewModel, CancellationToken cancellationToken);
        Task DeletarProdutoAsync(Guid idProduto, CancellationToken cancellationToken);
    }
}
