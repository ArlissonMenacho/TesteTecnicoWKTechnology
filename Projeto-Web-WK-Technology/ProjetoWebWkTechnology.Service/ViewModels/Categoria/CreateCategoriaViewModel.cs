namespace ProjetoWebWkTechnology.Service.ViewModels.Categoria
{
    public class CreateCategoriaViewModel
    {
        public CreateCategoriaViewModel(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
