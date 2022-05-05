namespace ApiWkTechnology.Service.ViewModels.Produto
{
    public class CreateProdutoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string Marca { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
