using JobHunt.Application.JobSeekers;

namespace JobHunt.Presentation.Models;

public class JobSeekerViewModel
{
    public JobSeekerDto JobSeeker { get; set; } = default!;
    public IFormFile? UploadedCV{ get; set; }
}
