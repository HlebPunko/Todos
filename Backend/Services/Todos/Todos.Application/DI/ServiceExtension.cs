using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Todos.Application.Services;
using Todos.Application.Services.Interfaces;

namespace Todos.Application.DI
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<INoteBookService, NoteBookService>();
            services.AddScoped<INoteService, NoteService>();

            return services;
        }
    }
}
