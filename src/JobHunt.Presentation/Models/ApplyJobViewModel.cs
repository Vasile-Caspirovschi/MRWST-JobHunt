using System.Reflection.Metadata.Ecma335;

namespace JobHunt.Presentation.Models;

public class ApplyJobViewModel
{
    public Guid JobId { get; set; }
    public Guid ApplicantId { get; set; }
    public Guid CompanyId { get; set; }
    public string ApplicantFullname { get; set; } = default!;
    public string ApplicantEmail { get; set; } = default!;
}
