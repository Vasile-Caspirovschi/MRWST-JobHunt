namespace JobHunt.Application.Companies;

public class CompanyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set;}
    public string? Phone { get; set;}
    public Guid? RepresentativeId { get; set; }
    public string? Location { get; set; } = default!;
    public string? LogoUrl { get; set; }
    public string? LogoId { get; set; }

    public bool IsCompanyProfileComplete()
    {
        return !string.IsNullOrWhiteSpace(Name)
            && !string.IsNullOrWhiteSpace(Description)
            && !string.IsNullOrWhiteSpace(Phone)
            && !string.IsNullOrWhiteSpace(Location)
            && !string.IsNullOrEmpty(LogoUrl);
    }
}