using JobHunt.Domain.Entities;

namespace JobHunt.Domain.Shared;

public class JobPostFilterParams
{
    public string ByCategory { get; set; } = "any";
    public string ByType { get; set; } = "any";
    public string ByLocation { get; set; } = "any";
    public string ByExperience { get; set; } = "any";
    public string ByPostedDate { get; set; } = "any";
    public string SearchKey { get; set; } = string.Empty;

    public JobPostFilterParams()
    {

    }

    public JobPostFilterParams(string searchKey = "", string byCategory = "any", string byType = "any", string byLocation = "any", string byExperience = "any", string byPostedDate = "any")
    {
        SearchKey = searchKey;
        ByCategory = byCategory;
        ByType = byType;
        ByLocation = byLocation;
        ByExperience = byExperience;
        ByPostedDate = byPostedDate;
    }
}