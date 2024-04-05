namespace JobHunt.Domain.Entities;

public class JobApplication
{
    public string ApplicantId { get; set; } = string.Empty!;
    public AppUser Applicant { get; set; } = default!;
    public Guid JobPostId { get; set; }
    public JobPost JobPost { get; set; } = default!;
    public DateOnly ApplicationDate { get; set; }
}
