using JobHunt.Application.JobSeekers;

namespace JobHunt.Application.JobApplications;
public class JobApplicationDto
{
    public string ApplicantFullname { get; set; } = default!;
    public string ApplicantEmail { get; set; } = default!;
    public CVDto? CV { get; set; } = default!;
    public Guid ApplicantId { get; set; }
    public Guid JobPostId { get; set; }
    public string JobTitle { get; set; } = default!;
    public Guid CompanyId { get; set; }
    public string CompanyName { get; set; } = default!;
    public DateOnly AppliedAt { get; set; }
}
