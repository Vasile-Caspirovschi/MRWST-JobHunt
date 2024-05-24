namespace JobHunt.Domain.Entities;

public class JobApplication
{
    public Guid Id { get; set; }
    public JobSeeker Applicant { get; set; } = default!;
    public Guid JobPostId { get; set; }
    public JobPost JobPost { get; set; } = default!;
    public Guid CompanyId { get; set; }
    public DateOnly ApplicationDate { get; set; }
}
