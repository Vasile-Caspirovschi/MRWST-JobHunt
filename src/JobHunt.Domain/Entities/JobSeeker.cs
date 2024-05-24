namespace JobHunt.Domain.Entities;

public class JobSeeker : AppUser
{
    public ICollection<JobApplication> JobApplications { get; set; } = [];
}
