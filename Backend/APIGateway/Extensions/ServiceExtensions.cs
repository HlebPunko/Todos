using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace APIGateway.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var authProviderKey = configuration["Auth:AuthenticationProviderKey"];
            var authority = configuration["Auth:Authority"];

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(authProviderKey, options =>
            {
                options.Authority = authority;
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
