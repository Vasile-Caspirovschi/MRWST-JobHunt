using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Enums;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobHunt.Application.Jobs.Queries;

public sealed record GetAllJobsPagedQuery(PaginationParams PaginationParams, JobPostFilterParams FilterParams) : IPagedQuery<JobPostDto>;

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
            CompanyLogoUrl = jobPost.Company.Logo != null ? jobPost.Company.Logo.ImageUrl : @"/images/placeholder.png",
            PublishDate = jobPost.PublishDate,
            CompanyName = jobPost.Company.Name
        };

        var includes = new List<Expression<Func<JobPost, object>>>()
        {
            jobPost => jobPost.Company,
            jobPost => jobPost.JobCategory,
        };

        Expression<Func<JobPost, bool>> filter = jobPost =>
            (request.FilterParams.ByCategory == "any" || jobPost.JobCategory.Title == request.FilterParams.ByCategory) &&
            (request.FilterParams.ByType == "any" || jobPost.JobType == request.FilterParams.ByType) &&
            (request.FilterParams.ByLocation == "any" || jobPost.Company.Location == request.FilterParams.ByLocation) &&
            (request.FilterParams.ByExperience == "any" || jobPost.Experience == request.FilterParams.ByExperience) &&
            (string.IsNullOrEmpty(request.FilterParams.SearchKey) ||
                EF.Functions.Like(jobPost.Title.ToLower(), $"%{request.FilterParams.SearchKey.ToLower()}%") ||
                EF.Functions.Like(jobPost.Company.Name.ToLower(), $"%{request.FilterParams.SearchKey.ToLower()}%"));

        return await _paginationService.GetPagedAsync(request.PaginationParams, mapper, includes, filter);
    }
}
