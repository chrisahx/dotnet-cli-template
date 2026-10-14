using DTest.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DTest.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    /// <summary>
    /// Register all dependencies and services for the application
    /// </sumary>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IPackageService, PackageService>(); 

        return services;
    }
}
