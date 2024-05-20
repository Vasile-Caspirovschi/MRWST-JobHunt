using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Jobs.Commands;

public sealed record DeleteJobPostByIdCommand(Guid JobPostId) : ICommand;

public class DeleteJobPostByIdHandler(IJobHuntDbContext dbContext) : ICommandHandler<DeleteJobPostByIdCommand>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result> Handle(DeleteJobPostByIdCommand request, CancellationToken cancellationToken)
    {
        var jobPost = await _dbContext.JobPosts.FirstOrDefaultAsync(job=> job.Id == request.JobPostId);
        if (jobPost is null)
        {
            return Result.Failure(new Error("DeleteJobPost.Failed","Job post not found"));
        }

        _dbContext.JobPosts.Remove(jobPost);
        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
            return Result.Success();
        return Result.Failure(new Error("DeleteJobPost.Failed", "Something went wrong when trying to delete the job post"));

    }
}