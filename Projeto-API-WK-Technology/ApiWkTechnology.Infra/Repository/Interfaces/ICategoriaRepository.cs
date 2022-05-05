using ApiWkTechnology.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWkTechnology.Infra.Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> BuscaTodosAsync(CancellationToken cancellationToken);
        Task<Categoria> BuscaPorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Categoria> CadastrarCategoriaAsync(Categoria categoria, CancellationToken cancellationToken);
        Task<Categoria> AtualizarCategoriaAsync(Categoria categoria, CancellationToken cancellationToken);
        Task DeletarCategoriaAsync(Guid idCategoria, CancellationToken cancellationToken);
    }
}