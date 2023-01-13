using Identity.Application.Services.Interfaces;
using Identity.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Identity.Application.DI
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
