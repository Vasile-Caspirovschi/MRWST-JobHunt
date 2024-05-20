using JobHunt.Application.Jobs;

namespace JobHunt.Presentation.Models;

public class CreateEditJobPostViewModel
{
    public JobPostDto? JobPost { get; set; }
    public IEnumerable<string> Categories { get; set; } = [];
}
