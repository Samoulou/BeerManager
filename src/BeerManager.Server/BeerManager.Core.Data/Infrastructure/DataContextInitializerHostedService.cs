using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BeerManager.Core.Data.Models;

namespace BeerManager.Core.Data.Infrastructure;

internal class DataContextInitializerHostedService : IHostedService
{
    private IServiceScopeFactory ServiceScopeFactory { get; }

    public DataContextInitializerHostedService(IServiceScopeFactory serviceScopeFactory)
    {
        ServiceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await InitializeAsync(cancellationToken).ConfigureAwait(false);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private async Task InitializeAsync(CancellationToken cancellationToken)
    {
        using var serviceScope = ServiceScopeFactory.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetRequiredService<CoreContext>();

        await dbContext.Database.EnsureCreatedAsync(cancellationToken).ConfigureAwait(false);
    }
}