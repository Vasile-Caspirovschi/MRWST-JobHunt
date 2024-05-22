using JobHunt.Application.Companies;
using JobHunt.Application.Jobs;
using JobHunt.Domain.Enums;

namespace JobHunt.Presentation.Models;

public class JobViewModel
{
    public required JobPostDto JobPost { get; set; }
    public required CompanyDto Company { get; set; }

    public string ParseExperience()
    {
        return JobPost.Experience switch
        {
            //ExperienceRangeType.LessThanOneYear => "Less than 1 year",
            ExperienceRangeType.ZeroToOneYears => "Less than 1 year",
            ExperienceRangeType.OneToTwoYears => "1-2 years",
            ExperienceRangeType.TwoToThreeYears => "2-3 years",
            ExperienceRangeType.ThreeToSixYears => "3-6 years",
            ExperienceRangeType.SixOrMoreYears => "6+ years",
            _ => "Not specified"
        };
    }

}
