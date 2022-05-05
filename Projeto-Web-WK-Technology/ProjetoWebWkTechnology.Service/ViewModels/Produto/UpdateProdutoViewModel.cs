namespace ProjetoWebWkTechnology.Service.ViewModels.Produto
{
    public class UpdateProdutoViewModel
    {
        public UpdateProdutoViewModel()
        {

        }

        public UpdateProdutoViewModel(Guid id, string nome,string descricao, double preco,string marca)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Marca = marca;
            Preco = preco;
        }
        public UpdateProdutoViewModel(Guid id, string nome, string descricao, double preco,string marca, Guid categoriaId)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            CategoriaId = categoriaId;
            Marca = marca;
        }

        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double? Preco { get; set; }
        public string? Marca { get; set; }
        public Guid? CategoriaId { get; set; }
    }
}
