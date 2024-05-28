using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.JobSeekers.Queries;
public sealed record HasAppliedForJobPostQuery(Guid UserId, Guid JobPostId) : IQuery<bool>;

public class HasAppliedForJobPostHandler(IJobHuntDbContext dbContext) : IQueryHandler<HasAppliedForJobPostQuery, bool>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result<bool>> Handle(HasAppliedForJobPostQuery request, CancellationToken cancellationToken)
    {
        var jobSeeker = await _dbContext.JobSeekers
            .Include(x => x.JobApplications)
            .SingleOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
        if (jobSeeker is null)
        {
            return Result.Failure<bool>(new Error("HasAppliedForJobPost.Failed", "Job seeker not found"));
        }

        bool hasApplied = jobSeeker.JobApplications.Any(x => x.JobPostId == request.JobPostId);
        return hasApplied;
    }
}