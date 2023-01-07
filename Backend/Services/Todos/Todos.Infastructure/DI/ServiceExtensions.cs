using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todos.Infastructure.Context;

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

            return services;
        }
    }
}
