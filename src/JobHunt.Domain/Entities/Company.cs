using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set;} = string.Empty;
    public string? Phone { get; set;}

    [ForeignKey(nameof(Employer))]
    public Guid EmployerId { get; set; }
    public Employer Employer { get; set; } = default!;
    public string? Location { get; set; } = default!;
    public Image? Logo { get; set; }
}
