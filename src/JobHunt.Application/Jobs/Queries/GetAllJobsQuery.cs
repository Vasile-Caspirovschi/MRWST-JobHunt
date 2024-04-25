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
        var experienceRangeType = typeof(ExperienceRangeType);
        var jobTypeType = typeof(JobTypeType);

        Expression<Func<JobPost, JobPostDto>> mapper = jobPost => new JobPostDto()
        {
            Id = jobPost.Id,
            Title = jobPost.Title,
            Location = jobPost.Company.Location!,
            Experience = (ExperienceRangeType)Enum.Parse(experienceRangeType, jobPost.Experience, true),
            JobDescription = jobPost.JobDescription,
            JobSalary = jobPost.JobSalary,
            JobType = (JobTypeType)Enum.Parse(jobTypeType, jobPost.JobType, true),
            JobCategoryName = jobPost.JobCategory.Title,
            CompanyId = jobPost.CompanyId,
            CompanyLogoUrl = jobPost.Company.Logo != null ? jobPost.Company.Logo.ImageUrl : @"/images/placeholder.png"
        };

        var includes = new List<Expression<Func<JobPost, object>>>()
        {
            jobPost => jobPost.Company,
            jobPost => jobPost.JobCategory,
        };
        return await _paginationService.GetPagedAsync(request.PageNumber, request.PageSize, mapper, includes);
    }
}
