namespace JobHunt.Application.Users;

public class AppUserDto
{
    public Guid  Id { get; set; }
    public string Fullname { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
}
