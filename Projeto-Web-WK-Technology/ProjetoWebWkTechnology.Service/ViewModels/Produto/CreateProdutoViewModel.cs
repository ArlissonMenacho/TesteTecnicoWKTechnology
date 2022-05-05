namespace ProjetoWebWkTechnology.Service.ViewModels.Produto
{
    public class CreateProdutoViewModel
    {
        public CreateProdutoViewModel()
        {

        }
        public CreateProdutoViewModel(string nome,string descricao, double preco,string marca,Guid categoriaId)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Marca = marca;
            CategoriaId = categoriaId;
        }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string Marca { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
