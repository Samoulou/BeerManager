using Microsoft.Extensions.DependencyInjection;

namespace BeerManager.Core.Data.Infrastructure;

public static class HostingServiceCollections
{
    public static IServiceCollection AddHosting(this IServiceCollection services)
    {
        services.AddHostedService<DataContextInitializerHostedService>();

        return services;
    }
}