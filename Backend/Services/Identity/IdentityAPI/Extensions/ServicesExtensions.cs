using Identity.Domain.Entities;
using Identity.Infastructure.Context;
using IdentityAPI.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();
        }

        public static void ConfigureIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
               opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               x => x.MigrationsAssembly(typeof(Program).Assembly.GetName().Name)));

            services.AddIdentityServer()
            .AddTestUsers(IdentityConfiguration.GetTestUsers())
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly(typeof(Program).Assembly.GetName().Name));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly(typeof(Program).Assembly.GetName().Name));
            })
            .AddDeveloperSigningCredential()
            .AddAspNetIdentity<User>();
        }
    }
}
