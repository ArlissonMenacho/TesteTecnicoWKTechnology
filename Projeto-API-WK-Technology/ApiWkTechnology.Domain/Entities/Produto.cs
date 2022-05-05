namespace ApiWkTechnology.Domain.Entities
{
    public class Produto
    {
        public Produto()
        {

        }
        public Produto(Guid id, string descricao, string nome, double preco, string marca)
        {
            Id = id;
            Descricao = descricao;
            Nome = nome;
            Preco = preco;
            Marca = marca;
        }
        public Produto(Guid id, string descricao, string nome, double preco, string marca, Guid categoriaId)
        {
            Id = id;
            Descricao = descricao;
            Nome = nome;
            Preco = preco;
            Marca = marca;
            CategoriaId = categoriaId;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string Marca { get; set; }
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
