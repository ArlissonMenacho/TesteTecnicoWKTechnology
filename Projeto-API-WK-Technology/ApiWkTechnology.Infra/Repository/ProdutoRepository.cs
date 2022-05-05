using ApiWkTechnology.Domain.Entities;
using ApiWkTechnology.Infra.Context;
using ApiWkTechnology.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiWkTechnology.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly WkTechnologyContext _wkTechnologyContext;
        public ProdutoRepository(WkTechnologyContext wkTechnologyContext)
        {
            _wkTechnologyContext = wkTechnologyContext;
        }
        public async Task<List<Produto>> BuscaTodosAsync(CancellationToken cancellationToken)
        {
            var produtos = await _wkTechnologyContext.Produtos.Include(x => x.Categoria).ToListAsync();
            return produtos;
        }
        public async Task<Produto> BuscaPorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var produto = await _wkTechnologyContext.Produtos.Include(x => x.Categoria).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (produto == null)
                throw new Exception("Nenhum Produto encontrado com o ID informado!");

            return produto;
        }

        public async Task<Produto> CadastrarProdutoAsync(Produto produto, CancellationToken cancellationToken)
        {
            await _wkTechnologyContext.AddAsync(produto);
            await _wkTechnologyContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> AtualizarProdutoAsync(Produto produto, CancellationToken cancellationToken)
        {
            _wkTechnologyContext.Produtos.Update(produto);
            await _wkTechnologyContext.SaveChangesAsync();
            return produto;
        }
        public async Task DeletarProdutoAsync(Guid idProduto, CancellationToken cancellationToken)
        {
            var produto = await BuscaPorIdAsync(idProduto, cancellationToken);
            _wkTechnologyContext.Produtos.Remove(produto);
            await _wkTechnologyContext.SaveChangesAsync();
        }
    }
}
