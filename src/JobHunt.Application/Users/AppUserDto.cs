namespace JobHunt.Application.Users;

public class AppUserDto(string fullname, string email, string phone)
{
    public Guid  Id { get; set; }
    public string Fullname { get; set; } = fullname;
    public string Email { get; set; } = email;
    public string Phone { get; set; } = phone;

    public AppUserDto(): this("", "", "")
    {
        
    }
}
