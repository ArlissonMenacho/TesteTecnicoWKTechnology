using ApiWkTechnology.Infra.Repository;
using ApiWkTechnology.Infra.Repository.Interfaces;

namespace ApiWkTechnology.Configuration
{
    public static class AddRepositorys
    {
        public static void AddRepositorysExtension(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        }
    }
}
