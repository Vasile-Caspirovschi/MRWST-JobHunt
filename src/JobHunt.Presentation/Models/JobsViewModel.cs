using JobHunt.Application.Jobs;

namespace JobHunt.Presentation.Models;

public class JobsViewModel
{
    public IEnumerable<JobPostDto> Jobs { get; set; } = [];
    public IEnumerable<string> Categories { get; set; } = [];

    public PaginationViewModel? Pagination { get; set; }
}
