using JobHunt.Domain.Enums;

namespace JobHunt.Application.Jobs;

public class JobPostDto
{
    public Guid? Id { get; set; } = Guid.Empty;
    public string Title { get; set; } = string.Empty;
    public int JobSalary { get; set; }
    public string JobCategoryName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateOnly? PublishDate { get; set; }
    public string? CompanyLogoUrl { get; set; } = string.Empty;
    public string JobDescription { get; set; } = string.Empty;
    public JobTypeType JobType { get; set; }
    public ExperienceRangeType Experience { get; set; }
    public Guid? CompanyId { get; set; } = Guid.Empty;
    public string CompanyName { get; set; } = string.Empty;
}
