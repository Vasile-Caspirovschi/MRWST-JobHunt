using JobHunt.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JobHunt.Infrastructure.DbUp;

public static class DependencyInjection
{
    public static IServiceCollection AddUpgradeDatabase(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseUpgrader, DatabaseUpgrader>();
        return services;
    }
}