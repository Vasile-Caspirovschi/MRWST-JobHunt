using JobHunt.Application.Jobs;

namespace JobHunt.Presentation.Models;

public class CompanyJobPostsViewModel
{
    public IEnumerable<JobPostDtoStripped> JobPosts { get; set; } = [];
    public Guid? CurrentJobPostId { get; set; }
}
