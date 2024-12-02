using BelugaAPI.Provider.Providers;
using BelugaAPI.Provider.Providers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BelugaAPI.Provider;

public static class ServiceRegistration
{
    public static IServiceCollection AddProviderLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAssistantService, OpenAiService>();
        
        return services;
    }
}