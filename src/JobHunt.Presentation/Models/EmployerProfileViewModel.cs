using JobHunt.Application.Users;

namespace JobHunt.Presentation.Models;

public class EmployerProfileViewModel
{
    public AppUserDto Profile { get; set; } = default!;
}
