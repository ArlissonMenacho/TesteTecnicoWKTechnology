namespace ProjetoWebWkTechnology.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string PrecoInformado { get; set; }
        public string Marca { get; set; }
        public Guid CategoriaId { get; set; }
        public string CategoriaSelecionada { get; set; }
        public Categoria Categoria { get; set; }
    }
}
