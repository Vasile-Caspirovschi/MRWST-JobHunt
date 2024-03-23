namespace JobHunt.Domain.Entities;

public class JobPost
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int JobSalary { get; set; }
    public JobCategory JobCategory { get; set; } = default!;
    public Company Company { get; set; } = default!;
    public string JobDescription { get; set; } = string.Empty;
    public DateOnly PublishDate { get; set; }
    public JobTypeType JobType { get; set; }
}
