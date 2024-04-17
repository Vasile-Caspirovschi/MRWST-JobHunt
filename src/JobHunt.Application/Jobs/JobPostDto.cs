using JobHunt.Domain.Enums;

namespace JobHunt.Application.Jobs;

public class JobPostDto
{
    public Guid Id{ get; set; }
    public required string Title { get; set; }
    public required int JobSalary { get; set; }
    public string JobCategoryName { get; set; } = string.Empty;
    public required string Location { get; set; }
    //public Company Company { get; set; } = default!;
    public required string JobDescription { get; set; }
    public required JobTypeType JobType { get; set; }
    public required ExperienceRangeType Experience { get; set; }
}
