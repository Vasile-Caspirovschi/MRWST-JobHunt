using JobHunt.Domain.Entities;
using JobHunt.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace JobHunt.Presentation.Helpers;

public class AppUserClaimsFactory(UserManager<AppUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, IOptions<IdentityOptions> options) : UserClaimsPrincipalFactory<AppUser, IdentityRole<Guid>>(userManager, roleManager, options)
{
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        if (await UserManager.IsInRoleAsync(user, nameof(UserRoleType.Employer)))
        {
            if (user is Employer employer)
            {
                identity.AddClaim(new Claim("CompanyId", employer.CompanyId.ToString()));
            }
        }
        return identity;
    }

}
