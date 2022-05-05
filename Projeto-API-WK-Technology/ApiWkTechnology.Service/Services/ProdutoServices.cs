using ApiWkTechnology.Domain.Entities;
using ApiWkTechnology.Infra.Repository.Interfaces;
using ApiWkTechnology.Service.Interfaces;
using ApiWkTechnology.Service.ViewModels.Produto;

namespace ApiWkTechnology.Service.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoServices(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<Produto>> BuscaTodosAsync(CancellationToken cancellationToken)
        {
            var produtos = await _produtoRepository.BuscaTodosAsync(cancellationToken);
            return produtos;
        }

        public async Task<Produto> BuscaPorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.BuscaPorIdAsync(id, cancellationToken);
            return produto;
        }

        public async Task<Produto> CadastrarProdutoAsync(CreateProdutoViewModel viewModel, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(viewModel.Nome) && !string.IsNullOrEmpty(viewModel.Descricao)
                && !string.IsNullOrEmpty(viewModel.Marca) && viewModel.CategoriaId != Guid.Empty && viewModel.Preco > 0)
            {
                var produto = new Produto(Guid.NewGuid(), viewModel.Descricao, viewModel.Nome, viewModel.Preco, viewModel.Marca, viewModel.CategoriaId);
                return await _produtoRepository.CadastrarProdutoAsync(produto, cancellationToken);
            }
            else
            {
                throw new Exception("Não foi possível cadastrar o produto verifique os dados informados e tente novamente.");
            }
        }

        public async Task<Produto> AtualizarProdutoAsync(UpdateProdutoViewModel viewModel, CancellationToken cancellationToken)
        {
            if (viewModel.Id != Guid.Empty)
            {
                var produto = await BuscaPorIdAsync(viewModel.Id, cancellationToken);

                if (!string.IsNullOrEmpty(viewModel.Nome))
                {
                    produto.Nome = viewModel.Nome;
                }
                if (!string.IsNullOrEmpty(viewModel.Descricao))
                {
                    produto.Descricao = viewModel.Descricao;
                }
                if (!string.IsNullOrEmpty(viewModel.Marca))
                {
                    produto.Marca = viewModel.Marca;
                }
                if (viewModel.Preco != null)
                {
                    produto.Preco = viewModel.Preco.Value;
                }
                if (viewModel.CategoriaId != null)
                {
                    if (viewModel.CategoriaId != Guid.Empty)
                    {
                        produto.CategoriaId = viewModel.CategoriaId.Value;
                    }
                }
                return await _produtoRepository.AtualizarProdutoAsync(produto, cancellationToken);
            }
            else
            {
                throw new Exception("Não é possível atualizar um produto sem ID");
            }
            throw new Exception("Produto não passou nos parametros de validação.");
        }

        public async Task DeletarProdutoAsync(Guid idProduto, CancellationToken cancellationToken)
        {
            await _produtoRepository.DeletarProdutoAsync(idProduto, cancellationToken);
        }
    }
}
