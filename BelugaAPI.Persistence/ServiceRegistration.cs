using BelugaAPI.Persistence.Context;
using BelugaAPI.Persistence.Interfaces;
using BelugaAPI.Persistence.Repositories;
using BelugaAPI.Persistence.Services;
using BelugaAPI.Persistence.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BelugaAPI.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("BelugaPocDb"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        
        services.AddScoped<IStorageService, AzureStorageService>();
        
        return services;
    }
}