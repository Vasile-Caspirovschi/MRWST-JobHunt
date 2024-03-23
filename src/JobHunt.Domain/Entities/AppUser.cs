namespace JobHunt.Domain.Entities;

public class AppUser
{
    public Guid Id { get; set; }
    public string UserName { get; set; }= string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRoleType UserRole { get; set; }
}
