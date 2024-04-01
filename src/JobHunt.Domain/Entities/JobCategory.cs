namespace JobHunt.Domain.Entities;

public class JobCategory
{
    public Guid CategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
}
