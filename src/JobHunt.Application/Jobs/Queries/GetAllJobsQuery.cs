using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Enums;
using JobHunt.Domain.Shared;
using System.Linq.Expressions;

namespace JobHunt.Application.Jobs.Queries;

public sealed record GetAllJobsPagedQuery(int PageNumber, int PageSize) : IPagedQuery<JobPostDto>;

public class GetAllJobsQueryHandler(IPaginationService<JobPost, JobPostDto> paginationService) : IPagedQueryHandler<GetAllJobsPagedQuery, JobPostDto>
{
    private readonly IPaginationService<JobPost, JobPostDto> _paginationService = paginationService;

    public async Task<PagedResult<JobPostDto>> Handle(GetAllJobsPagedQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<JobPost, JobPostDto>> mapper = jopPost => new JobPostDto()
        {
            Title = jopPost.Title,
            Location = jopPost.Company.Location!,
            Experience = (ExperienceRangeType)Enum.Parse(typeof(ExperienceRangeType), jopPost.Experience, true),
            JobDescription = jopPost.JobDescription,
            JobSalary = jopPost.JobSalary,
            JobType = (JobTypeType)Enum.Parse(typeof(JobTypeType), jopPost.JobType, true),
        };
        return await _paginationService.GetPagedAsync(request.PageNumber, request.PageSize, mapper);
    }
}
