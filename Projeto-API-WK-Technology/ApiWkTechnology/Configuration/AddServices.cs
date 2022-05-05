using ApiWkTechnology.Service.Interfaces;
using ApiWkTechnology.Service.Services;

namespace ApiWkTechnology.Configuration
{
    public static class AddServices
    {
        public static void AddServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IProdutoServices, ProdutoServices>();
            services.AddScoped<ICategoriaServices, CategoriaServices>();
        }
    }
}
