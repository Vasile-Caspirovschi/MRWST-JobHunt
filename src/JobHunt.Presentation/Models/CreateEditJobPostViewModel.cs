using JobHunt.Application.Companies;
using JobHunt.Application.Jobs;

namespace JobHunt.Presentation.Models;

public class CreateEditJobPostViewModel
{
    public JobPostDto? JobPost { get; set; }
    public CompanyDto CompanyDto { get; set; } = default!;
    public IEnumerable<string> Categories { get; set; } = [];

    public string AlertMessage { get; set; } = "You must complete the company's profile before being able to post your jobs!";
}
