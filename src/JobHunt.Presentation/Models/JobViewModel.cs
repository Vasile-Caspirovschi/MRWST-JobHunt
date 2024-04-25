using JobHunt.Application.Companies;
using JobHunt.Application.Jobs;

namespace JobHunt.Presentation.Models;

public class JobViewModel
{
    public required JobPostDto JobPost { get; set; }
    public required CompanyDto Company { get; set; }
}
