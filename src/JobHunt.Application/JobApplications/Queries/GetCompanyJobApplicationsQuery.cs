using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Application.JobSeekers;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.JobApplications.Queries;
public sealed record GetCompanyJobApplicationsQuery(Guid CompanyId) : IQuery<IEnumerable<JobApplicationDto>>;

public class GetCompanyJobApplicationsHanlder(IJobHuntDbContext dbContext) : IQueryHandler<GetCompanyJobApplicationsQuery, IEnumerable<JobApplicationDto>>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result<IEnumerable<JobApplicationDto>>> Handle(GetCompanyJobApplicationsQuery request, CancellationToken cancellationToken)
    {
        var jobApplications = await _dbContext.JobApplications
            .Include(x => x.JobPost)
            .ThenInclude(x => x.Company)
            .Include(x => x.Applicant)
            .ThenInclude(x => x.CV)
            .Where(x => x.CompanyId == request.CompanyId)
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
                CV = new CVDto(jobApplication.Applicant.CV.FileName, jobApplication.Applicant.CV.FileUrl)
            })
            .AsSplitQuery()
            .ToListAsync();
        return jobApplications;
    }
}
