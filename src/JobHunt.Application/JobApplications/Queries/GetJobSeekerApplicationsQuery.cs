using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Application.JobSeekers;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.JobApplications.Queries;
public sealed record GetJobSeekerApplicationsQuery(Guid UserId) : IQuery<IEnumerable<JobApplicationDto>>;

public class GetJobSeekerApplicationHandler(IJobHuntDbContext dbContext) : IQueryHandler<GetJobSeekerApplicationsQuery, IEnumerable<JobApplicationDto>>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result<IEnumerable<JobApplicationDto>>> Handle(GetJobSeekerApplicationsQuery request, CancellationToken cancellationToken)
    {
        var jobApplications = await _dbContext.JobApplications
            .Include(x => x.JobPost)
            .ThenInclude(x => x.Company)
            .Where(x => x.ApplicantId == request.UserId)
            .Select(jobApplication => new JobApplicationDto()
            {
                ApplicantFullname = jobApplication.ApplicantFullname,
                ApplicantEmail = jobApplication.ApplicantEmail,
                ApplicantId = jobApplication.ApplicantId,
                JobPostId = jobApplication.JobPostId,
                JobTitle = jobApplication.JobPost.Title,
                CompanyId = jobApplication.CompanyId,
                CompanyName = jobApplication.JobPost.Company.Name,
                AppliedAt = jobApplication.ApplicationDate,
            })
            .AsSplitQuery()
            .ToListAsync();
        return jobApplications;
    }
}
