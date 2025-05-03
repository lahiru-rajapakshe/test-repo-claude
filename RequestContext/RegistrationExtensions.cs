using Microsoft.Extensions.DependencyInjection;

namespace Common.RequestContext;

public static class RegistrationExtensions
{
    /// <summary>
    /// Registers the request context as a scoped service.
    /// </summary>
    /// <param name="services"></param>
    public static void AddRequestContext(this IServiceCollection services)
    {
        services.AddScoped<RequestContext>();
        services.AddScoped<IRequestContext>(x => x.GetRequiredService<RequestContext>());
        services.AddScoped<IMutableRequestContext>(x => x.GetRequiredService<RequestContext>());
    }
}