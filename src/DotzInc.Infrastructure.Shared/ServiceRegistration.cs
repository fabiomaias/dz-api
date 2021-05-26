using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotzInc.Domain.Settings;

namespace DotzInc.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<DzConvert>(_config.GetSection("DzConvertSettings"));
            services.AddAuthenticationService();
        }
    }
}
