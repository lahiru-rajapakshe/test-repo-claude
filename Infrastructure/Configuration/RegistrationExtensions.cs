using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure.Configuration
{
    public static class RegistrationExtensions
    {
        public static void AddOptions<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class
        {
            services.Configure<TConfig>(options => configuration.GetSection(typeof(TConfig).Name).Bind(options));
        }
    }
}
