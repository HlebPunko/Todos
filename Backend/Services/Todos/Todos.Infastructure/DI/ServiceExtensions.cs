using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todos.Infastructure.Context;
using Todos.Infastructure.Repositories;
using Todos.Infastructure.Repositories.Interfaces;

namespace Todos.Infastructure.DI
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodosDbContext>((DbContextOptionsBuilder options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));
            });

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddScoped<IRepositoryManager, RepositoryManager>();

            return services;
        }
    }
}
