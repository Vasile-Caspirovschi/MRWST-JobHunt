using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Jobs.Commands;

//public sealed record CreateJobPostCommand(
//    string Title,
//    int JobSalary,
//    string JobCategoryName,
//    string Location,
//    string JobDescription,
//    JobTypeType JobType,
//    ExperienceRangeType Experience) : ICommand;

public sealed record CreateJobPostCommand(JobPostDto JobPost) : ICommand;

public class CreateJobPostCommandHandler(IJobHuntDbContext dbContext) : ICommandHandler<CreateJobPostCommand>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result> Handle(CreateJobPostCommand request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.JobCategories.FirstOrDefaultAsync(c => c.Title == request.JobPost.JobCategoryName);

        if (category is null)
        {
            return Result.Failure(new Error("CreateJobPost.Failed", "Job category not found"));
        }

        JobPost newJobPost = new()
        {
            Title = request.JobPost.Title,
            JobSalary = request.JobPost.JobSalary,
            JobCategory = category,
            CompanyId = request.JobPost.CompanyId ?? Guid.Empty,
            JobDescription = request.JobPost.JobDescription,
            JobType = request.JobPost.JobType.ToString(),
            Experience = request.JobPost.Experience.ToString(),
            PublishDate = DateOnly.FromDateTime(DateTime.UtcNow)
        };

        _dbContext.JobPosts.Add(newJobPost);
        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
            return Result.Success();
        return Result.Failure(new Error("CreateJobPost.Failed", "Something went wrong when trying to create this job post"));
    }
}