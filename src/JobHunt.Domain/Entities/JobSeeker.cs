namespace JobHunt.Domain.Entities;

public class JobSeeker : AppUser
{
    public Guid? CVId { get; set; }
    public CV? CV { get; set; }
    public ICollection<JobApplication> JobApplications { get; set; } = [];
}
