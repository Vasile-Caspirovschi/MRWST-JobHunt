using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Application.Users;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.JobSeekers.Queries;

public sealed record GetJobSeekerByIdQuery(Guid Id) : IQuery<JobSeekerDto>;

public class GetJobSeekerByIdHandler(IJobHuntDbContext dbContext) : IQueryHandler<GetJobSeekerByIdQuery, JobSeekerDto>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result<JobSeekerDto>> Handle(GetJobSeekerByIdQuery request, CancellationToken cancellationToken)
    {
        var jobSeeker = await _dbContext.JobSeekers
            .Include(x => x.CV)
            .Include(x => x.JobApplications)
            .OrderBy(x => x.Id)
            .AsSplitQuery()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (jobSeeker is null)
        {
            return Result.Failure<JobSeekerDto>(new Error("GetJobSeeker.Failed", "Job seeker not found"));
        }

        CVDto? cVDto = null;
        if (jobSeeker.CV is not null)
        {
            cVDto = new CVDto(jobSeeker.CV.FileName, jobSeeker.CV.FileUrl);
        }

        return new JobSeekerDto()
        {
            Id = jobSeeker.Id,
            Profile = new AppUserDto(jobSeeker.UserName, jobSeeker.Email, jobSeeker.PhoneNumber),
            CV = cVDto,
            JobApplicationsCount = jobSeeker.JobApplications.Count(),
            FavoriteJobPosts = 0,
            HasUploadedCV = jobSeeker.CV is not null
        };
    }
}