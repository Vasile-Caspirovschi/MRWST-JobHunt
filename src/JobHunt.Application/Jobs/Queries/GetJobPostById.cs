using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Enums;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Jobs.Queries;

public record GetJobPostById(Guid JobPostId) : IQuery<JobPostDto>;

public class GetJobPostByIdHandler(IJobHuntDbContext dbContext) : IQueryHandler<GetJobPostById, JobPostDto>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result<JobPostDto>> Handle(GetJobPostById request, CancellationToken cancellationToken)
    {
        var experienceRangeType = typeof(ExperienceRangeType);
        var jobTypeType = typeof(JobTypeType);

        var jobPost = await _dbContext.JobPosts
            .Include(job => job.Company)
            .Include(job => job.JobCategory)
            .SingleOrDefaultAsync(job => job.Id == request.JobPostId, cancellationToken);

        if (jobPost is null)
            return Result.Failure<JobPostDto>(new Error("GetJobPost.Failed", "Job post not found"));

        return new JobPostDto()
        {
            Title = jobPost.Title,
            Location = jobPost.Company.Location!,
            Experience = (ExperienceRangeType)Enum.Parse(experienceRangeType, jobPost.Experience, true),
            JobDescription = jobPost.JobDescription,
            JobSalary = jobPost.JobSalary,
            JobType = (JobTypeType)Enum.Parse(jobTypeType, jobPost.JobType, true),
            JobCategoryName = jobPost.JobCategory.Title,
            CompanyId = jobPost.CompanyId,
            PublishDate = jobPost.PublishDate,
            CompanyLogoUrl = jobPost.Company.Logo?.ImageUrl,
        };
    }
}