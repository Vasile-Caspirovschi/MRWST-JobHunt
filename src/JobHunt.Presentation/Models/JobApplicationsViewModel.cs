using JobHunt.Application.JobApplications;

namespace JobHunt.Presentation.Models;

public class JobApplicationsViewModel
{
    public IEnumerable<JobApplicationDto> JobApplications { get; set; } = [];
}
