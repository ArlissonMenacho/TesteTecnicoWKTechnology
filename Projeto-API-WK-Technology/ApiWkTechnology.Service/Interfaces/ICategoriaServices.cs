using ApiWkTechnology.Domain.Entities;
using ApiWkTechnology.Service.ViewModels.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWkTechnology.Service.Interfaces
{
    public interface ICategoriaServices
    {
        Task<List<Categoria>> BuscaTodasAsync(CancellationToken cancellationToken);
        Task<Categoria> BuscaPorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Categoria> CadastrarCategoriaAsync(CreateCategoriaViewModel viewModel, CancellationToken cancellationToken);
        Task<Categoria> AtualizarCategoriaAsync(UpdateCategoriaViewModel viewModel, CancellationToken cancellationToken);
        Task DeletarCategoriaAsync(Guid idCategoria, CancellationToken cancellationToken);
    }
}
