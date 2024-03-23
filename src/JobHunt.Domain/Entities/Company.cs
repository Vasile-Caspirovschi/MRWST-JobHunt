namespace JobHunt.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set;} = string.Empty;
    public string? Phone { get; set;}
    public AppUser Reprezentative = default!;
    public string? Location { get; set; } = default!;
}
