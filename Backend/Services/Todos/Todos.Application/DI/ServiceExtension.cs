using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Todos.Application.DI
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
