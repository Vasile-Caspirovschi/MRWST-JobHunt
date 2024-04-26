using JobHunt.Domain.Entities;

namespace JobHunt.Domain.Shared;

public class JobPostFilterParams
{
    public string ByCategory { get; set; } = "any";
    public string ByType { get; set; } = "any";
    public string ByLocation { get; set; } = "any";
    public string ByExperience { get; set; } = "any";
    public string ByPostedDate { get; set; } = "any";

    public JobPostFilterParams()
    {

    }

    public JobPostFilterParams(string byCategory = "any", string byType = "any", string byLocation = "any", string byExperience = "any", string byPostedDate = "any")
    {
        ByCategory = byCategory;
        ByType = byType;
        ByLocation = byLocation;
        ByExperience = byExperience;
        ByPostedDate = byPostedDate;
    }


    public bool GetPredicate(JobPost jobPost)
    {
        return jobPost.Title.ToLower().Contains(ByCategory.ToLower())  ||
               jobPost.JobType.ToLower().Contains(ByType.ToLower()) ||
               jobPost.Company.Location.ToLower().Contains(ByLocation.ToLower()) ||
               jobPost.Experience.ToLower().Contains(ByExperience.ToLower());
    }
}