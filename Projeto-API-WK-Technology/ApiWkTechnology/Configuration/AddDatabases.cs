using ApiWkTechnology.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiWkTechnology.Configuration
{
    public static class AddDatabases
    {
        public static void AddDatabaseInfrastructure(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<WkTechnologyContext>(options =>
           options.UseMySql(configuration.GetConnectionString("WkTechnologyDatabase"), ServerVersion.Parse("8.0.29-mysql")));
        }
    }
}
