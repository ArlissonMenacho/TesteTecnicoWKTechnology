using ApiWkTechnology.Domain.Entities;
using ApiWkTechnology.Infra.Repository.Interfaces;
using ApiWkTechnology.Service.Interfaces;
using ApiWkTechnology.Service.ViewModels.Categoria;

namespace ApiWkTechnology.Service.Services
{
    public class CategoriaServices : ICategoriaServices
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaServices(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<Categoria>> BuscaTodasAsync(CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepository.BuscaTodosAsync(cancellationToken);
            return categorias;
        }

        public async Task<Categoria> BuscaPorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.BuscaPorIdAsync(id, cancellationToken);
            return categoria;
        }

        public async Task<Categoria> CadastrarCategoriaAsync(CreateCategoriaViewModel viewModel, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(viewModel.Nome) && !string.IsNullOrEmpty(viewModel.Descricao))
            {
                var categoria = new Categoria(Guid.NewGuid(), viewModel.Nome, viewModel.Descricao);
                return await _categoriaRepository.CadastrarCategoriaAsync(categoria, cancellationToken);
            }
            else
            {
                throw new Exception("Não foi possível cadastrar a categoria verifique os dados informados e tente novamente.");
            }
        }

        public async Task<Categoria> AtualizarCategoriaAsync(UpdateCategoriaViewModel viewModel, CancellationToken cancellationToken)
        {
            if (viewModel.Id != Guid.Empty)
            {
                var categoria = await BuscaPorIdAsync(viewModel.Id, cancellationToken);

                if (!string.IsNullOrEmpty(viewModel.Nome))
                {
                    categoria.Nome = viewModel.Nome;
                }
                if (!string.IsNullOrEmpty(viewModel.Descricao))
                {
                    categoria.Descricao = viewModel.Descricao;
                }
                return await _categoriaRepository.AtualizarCategoriaAsync(categoria, cancellationToken);
            }
            else
            {
                throw new Exception("Não é possível atualizar uma categoria sem ID");
            }

            throw new Exception("Categoria não passou nos parâmetros de validação.");
        }

        public async Task DeletarCategoriaAsync(Guid idCategoria, CancellationToken cancellationToken)
        {
            await _categoriaRepository.DeletarCategoriaAsync(idCategoria, cancellationToken);
        }
    }
}
