using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Jobs.Queries;

public sealed record GetCompanyJobPostsQuery(Guid CompanyId) : IQuery<IEnumerable<JobPostDtoStripped>>;

public class GetCompanyJobPostsHandler(IJobHuntDbContext dbContext) : IQueryHandler<GetCompanyJobPostsQuery, IEnumerable<JobPostDtoStripped>>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result<IEnumerable<JobPostDtoStripped>>> Handle(GetCompanyJobPostsQuery request, CancellationToken cancellationToken)
    {
        var jobPosts = await _dbContext.JobPosts
            .Where(jobPost => jobPost.CompanyId == request.CompanyId)
            .Select(job => new JobPostDtoStripped(job.Id, job.Title, job.PublishDate))
            .AsNoTracking()
            .ToListAsync();
        return jobPosts;
    }
}