using JobHunt.Application.Companies;

namespace JobHunt.Presentation.Models;

public class CompanyViewModel
{
    public CompanyViewModel()
    {
        Company = new CompanyDto();
    }

    public CompanyViewModel(CompanyDto company)
    {
        Company = company;
    }

    public CompanyDto Company { get; set; }
    public IFormFile? UploadedLogo { get; set; }
}
