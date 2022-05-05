namespace ProjetoWebWkTechnology.Service.ViewModels.Categoria
{
    public class UpdateCategoriaViewModel
    {
        public UpdateCategoriaViewModel()
        {

        }
        public UpdateCategoriaViewModel(Guid id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
