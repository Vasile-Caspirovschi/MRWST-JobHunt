namespace JobHunt.Domain.Entities;
public class Employer : AppUser
{
    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = default!;
}
