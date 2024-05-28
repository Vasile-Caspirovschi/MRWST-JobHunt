using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Jobs.Commands;

public sealed record UpdateJobPostCommand(JobPostDto JobPost) : ICommand;

public class UpdateJobPostHandler(IJobHuntDbContext dbContext) : ICommandHandler<UpdateJobPostCommand>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result> Handle(UpdateJobPostCommand request, CancellationToken cancellationToken)
    {
        var jobPost = await _dbContext.JobPosts.Include(job => job.JobCategory)
            .FirstOrDefaultAsync(job => job.Id == request.JobPost.Id);
        if (jobPost is null)
        {
            return Result.Failure(new Error("UpdateJobPost.Failed", "Job post not found"));
        }

        jobPost.Title = request.JobPost.Title;
        jobPost.JobSalary = request.JobPost.JobSalary;
        jobPost.JobCategory = _dbContext.JobCategories.First();
        jobPost.JobDescription = request.JobPost.JobDescription;
        jobPost.JobType = request.JobPost.JobType.ToString();
        jobPost.Experience = request.JobPost.Experience.ToString();

        if (jobPost.JobCategory.Title != request.JobPost.JobCategoryName)
        {
            var category = _dbContext.JobCategories.FirstOrDefault(c => c.Title == request.JobPost.JobCategoryName);
            if (category is null)
                return Result.Failure(new Error("UpdateJobPost.Failed", "Could not update job category"));
            jobPost.JobCategory = category;
        }
        _dbContext.JobPosts.Update(jobPost);

        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
            return Result.Success();

        return Result.Failure(new Error("UpdateJobPost.Failed", "Something went wrong when trying to update the job post"));
    }
}
