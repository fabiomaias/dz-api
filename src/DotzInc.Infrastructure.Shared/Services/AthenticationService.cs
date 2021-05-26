using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace DotzInc.Infrastructure.Shared
{
    public static class AuthenticationService
    {
        public static void AddAuthenticationService(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.Authority = "https://securetoken.google.com/dotz-1e9a4";
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidIssuer = "https://securetoken.google.com/dotz-1e9a4",
                           ValidateAudience = true,
                           ValidAudience = "dotz-1e9a4",
                           ValidateLifetime = true
                       };
                   });
        }
    }
}
