using BelugaAPI.Application.Services.Interfaces;
using BelugaAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BelugaAPI.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccessKeyService, AccessKeyService>();
        services.AddScoped<IVideoService, VideoService>();
        services.AddScoped<ITranslationService, TranslationService>();
        services.AddScoped<IChatService, ChatService>();

        return services;
    }
}