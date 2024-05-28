using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Companies.Queries;

public sealed record GetCompanyStatisticQuery(Guid CompanyId) : IQuery<StatisticDto>;

public class GetCompanyStatisticHandler(IJobHuntDbContext dbContext) : IQueryHandler<GetCompanyStatisticQuery, StatisticDto>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result<StatisticDto>> Handle(GetCompanyStatisticQuery request, CancellationToken cancellationToken)
    {
        int jobPostCount = await _dbContext.JobPosts.CountAsync(jobPost => jobPost.CompanyId == request.CompanyId);
        int applicationsCount = await _dbContext.JobApplications.CountAsync(application => application.CompanyId == request.CompanyId);
        return new StatisticDto(jobPostCount, applicationsCount, applicationsCount);
    }
}