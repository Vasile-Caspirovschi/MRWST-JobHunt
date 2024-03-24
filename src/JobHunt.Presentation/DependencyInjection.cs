using JobHunt.Domain.Entities;
using JobHunt.Infrastracture.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
namespace JobHunt.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = false;
        }).AddEntityFrameworkStores<JobHuntDbContext>().AddDefaultTokenProviders(); 
        services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, opt => opt.LoginPath = "/auth/login");
        return services;
    }
}
