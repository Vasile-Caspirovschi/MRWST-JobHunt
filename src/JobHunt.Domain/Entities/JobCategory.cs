namespace JobHunt.Domain.Entities;

public class JobCategory
{
    public Guid CategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public Guid JobPostId { get; set; }
    public JobPost JobPost { get; set; } = default!;
}
