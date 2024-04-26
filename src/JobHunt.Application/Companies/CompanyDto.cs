namespace JobHunt.Application.Companies;

public class CompanyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set;} = string.Empty;
    public string? Phone { get; set;}
    public string? CompanyRepresentativeId { get; set; }
    public string? Location { get; set; } = default!;
    public string? LogoUrl { get; set; }
    public string? LogoId { get; set; }
}