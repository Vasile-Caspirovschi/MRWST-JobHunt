namespace JobHunt.Domain.Entities;

public class JobApplication
{
    public Guid Id { get; set; }
    public Guid ApplicantId { get; set; }
    public JobSeeker Applicant { get; set; } = default!;
    public string ApplicantFullname { get; set; } = default!;
    public string ApplicantEmail { get; set; } = default!;
    public Guid JobPostId { get; set; }
    public JobPost JobPost { get; set; } = default!;
    public Guid CompanyId { get; set; }
    public DateOnly ApplicationDate { get; set; }
}
