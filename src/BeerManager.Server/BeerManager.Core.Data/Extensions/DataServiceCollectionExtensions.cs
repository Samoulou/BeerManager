using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using BeerManager.Core.Data.Models;

namespace BeerManager.Core.Data.Extensions;
public static class DataServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
    {
        services.AddDbContext<ICoreContext, CoreContext>(dbOptions =>
        {
            dbOptions.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), optionsBuilder =>
            {
                optionsBuilder.EnableRetryOnFailure();
            });
            dbOptions.ConfigureWarnings(b =>
            {
                if (environment.IsDevelopment())
                {
                    b.Default(WarningBehavior.Throw);
                    b.Ignore(CoreEventId.SensitiveDataLoggingEnabledWarning);
                }
                else
                {
                    b.Default(WarningBehavior.Log);
                }
            });
            dbOptions.EnableSensitiveDataLogging(environment.IsDevelopment());
            dbOptions.EnableDetailedErrors(environment.IsDevelopment());
        });

        return services;
    }
}