using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace JobHunt.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>(options => { options.User.RequireUniqueEmail = false; })
            .AddEntityFrameworkStores<JobHuntDbContext>().AddDefaultTokenProviders();
        services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
            opt => opt.LoginPath = "/auth/login");
        return services;
    }

    public static async Task<IHost> UpgradeDatabase(this IHost host, CancellationToken cancellationToken)
    {
        using (var scope = host.Services.CreateScope())
        {
            using var context = scope.ServiceProvider.GetService<IJobHuntDbContext>()!;
            try
            {
                await context.MigrateAsync(cancellationToken);

                var databaseUpgrader = scope.ServiceProvider.GetService<IDatabaseUpgrader>();
                databaseUpgrader?.PerformUpgrade();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred creating the database. Error: {ex.Message}", ex);
            }
        }

        return host;
    }
}