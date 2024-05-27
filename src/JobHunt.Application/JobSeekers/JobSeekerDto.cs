using JobHunt.Application.Users;

namespace JobHunt.Application.JobSeekers;

public class JobSeekerDto
{
    public AppUserDto Profile { get; set; } = default!;
    public CVDto? CV { get; set; } = default!;
    public int JobApplicationsCount { get; set; }
    public int FavoriteJobPosts { get; set; }

    public bool HasUploadedCV { get; set; }
}
