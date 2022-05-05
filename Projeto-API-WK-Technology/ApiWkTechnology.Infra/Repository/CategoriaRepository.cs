using ApiWkTechnology.Domain.Entities;
using ApiWkTechnology.Infra.Context;
using ApiWkTechnology.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiWkTechnology.Infra.Repository
{
    public class CategoriaRepository:ICategoriaRepository
    {
        private readonly WkTechnologyContext _wkTechnologyContext;
        public CategoriaRepository(WkTechnologyContext wkTechnologyContext)
        {
            _wkTechnologyContext = wkTechnologyContext;
        }
        public async Task<List<Categoria>> BuscaTodosAsync(CancellationToken cancellationToken)
        {
            var categorias = await _wkTechnologyContext.Categorias.ToListAsync();
            return categorias;
        }
        public async Task<Categoria> BuscaPorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var categoria = await _wkTechnologyContext.Categorias.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (categoria == null)
                throw new Exception("Nenhum Categoria encontrada com o ID informado!");

            return categoria;
        }

        public async Task<Categoria> CadastrarCategoriaAsync(Categoria categoria, CancellationToken cancellationToken)
        {
            await _wkTechnologyContext.AddAsync(categoria);
            await _wkTechnologyContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> AtualizarCategoriaAsync(Categoria categoria, CancellationToken cancellationToken)
        {
            _wkTechnologyContext.Categorias.Update(categoria);
            await _wkTechnologyContext.SaveChangesAsync();
            return categoria;
        }
        public async Task DeletarCategoriaAsync(Guid idCategoria, CancellationToken cancellationToken)
        {
            var categoria = await BuscaPorIdAsync(idCategoria, cancellationToken);
            _wkTechnologyContext.Categorias.Remove(categoria);
            await _wkTechnologyContext.SaveChangesAsync();
        }
    }
}
