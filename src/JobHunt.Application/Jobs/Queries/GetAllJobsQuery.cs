using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Enums;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Jobs.Queries;

public sealed record GetAllJobsPagedQuery(PaginationParams PaginationParams, JobPostFilterParams FilterParams) : IPagedQuery<JobPostDto>;

public class GetAllJobsQueryHandler(IJobHuntDbContext dbContext, IPaginationService<JobPostDto> paginationService) : IPagedQueryHandler<GetAllJobsPagedQuery, JobPostDto>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;
    private readonly IPaginationService<JobPostDto> _paginationService = paginationService;

    public async Task<PagedResult<JobPostDto>> Handle(GetAllJobsPagedQuery request, CancellationToken cancellationToken)
    {
        var experienceRangeType = typeof(ExperienceRangeType);
        var jobTypeType = typeof(JobTypeType);

        var query = _dbContext.JobPosts
            .Include(job => job.Company)
            .Include(job => job.JobCategory)
            .Where(jobPost =>
                (request.FilterParams.ByCategory == "any" || jobPost.JobCategory.Title == request.FilterParams.ByCategory) &&
                (request.FilterParams.ByType == "any" || jobPost.JobType == request.FilterParams.ByType) &&
                (request.FilterParams.ByLocation == "any" || jobPost.Company.Location == request.FilterParams.ByLocation) &&
                (request.FilterParams.ByExperience == "any" || jobPost.Experience == request.FilterParams.ByExperience) &&
                (string.IsNullOrEmpty(request.FilterParams.SearchKey) ||
                    EF.Functions.Like(jobPost.Title.ToLower(), $"%{request.FilterParams.SearchKey.ToLower()}%") ||
                    EF.Functions.Like(jobPost.Company.Name.ToLower(), $"%{request.FilterParams.SearchKey.ToLower()}%")))
            .Select(jobPost => new JobPostDto()
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
            }).AsQueryable();

        query = request.FilterParams.SortByPostedDate == "oldest"
            ? query.OrderBy(job => job.PublishDate).ThenBy(job => job.Id)
            : query.OrderByDescending(job => job.PublishDate).ThenBy(job => job.Id);

        query = query.AsSplitQuery().AsNoTracking();
        
        return await _paginationService.GetPagedAsync(request.PaginationParams, query);
    }
}
