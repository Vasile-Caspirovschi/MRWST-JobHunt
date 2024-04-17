using JobHunt.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace JobHunt.Infrastracture.Persistence;

public static class DbSeeder
{
    public static async Task SeedRoles(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        await roleManager.CreateAsync(new IdentityRole(UserRoleType.Admin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(UserRoleType.Employer.ToString()));
        await roleManager.CreateAsync(new IdentityRole(UserRoleType.JobSeeker.ToString()));
    }
}
