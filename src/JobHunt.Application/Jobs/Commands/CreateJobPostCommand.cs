using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Enums;
using JobHunt.Domain.Shared;

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
        var newJobPost = new JobPost()
        {
            Title = request.JobPost.Title,
            JobSalary = request.JobPost.JobSalary,
            JobCategory = new JobCategory()
            {
                Title = request.JobPost.JobCategoryName?? "IT"
            },
            Company = new Company()
            {
                Location = request.JobPost.Location,
            },
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