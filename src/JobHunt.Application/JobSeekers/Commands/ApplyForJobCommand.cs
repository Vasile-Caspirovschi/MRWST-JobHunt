using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.JobSeekers.Commands;
public sealed record ApplyForJobCommand(
    string ApplicantFullname,
    string ApplicantEmail,
    Guid JobId,
    Guid ApplicantId,
    Guid CompanyId) : ICommand;

public class ApplyForJobHandler(IJobHuntDbContext dbContext) : ICommandHandler<ApplyForJobCommand>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result> Handle(ApplyForJobCommand request, CancellationToken cancellationToken)
    {
        bool jobSeekerExists = await _dbContext.JobSeekers.AnyAsync(x => x.Id == request.ApplicantId);
        bool jobPostExists = await _dbContext.JobPosts.AnyAsync(x => x.Id == request.JobId);
        bool companyExists = await _dbContext.Companies.AnyAsync(x => x.Id == request.CompanyId);

        if (!jobSeekerExists)
        {
            return Result.Failure(new Error("ApplyForJob.Failed", "Job seeker not found"));
        }

        if (!jobPostExists)
        {
            return Result.Failure(new Error("ApplyForJob.Failed", "Job post not found"));
        }

        if (!companyExists)
        {
            return Result.Failure(new Error("ApplyForJob.Failed", "Company not found"));
        }

        JobApplication newJobApplication = new()
        {
            ApplicantEmail = request.ApplicantEmail,
            ApplicantFullname = request.ApplicantFullname,
            ApplicantId = request.ApplicantId,
            CompanyId = request.CompanyId,
            JobPostId = request.JobId,
            ApplicationDate = DateOnly.FromDateTime(DateTime.Now)
        };

        _dbContext.JobApplications.Add(newJobApplication);

        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
        {
            return Result.Success();
        }
        return Result.Failure<CVDto>(new Error("ApplyForJob.Failed", "Something went wrong when trying to apply for the job"));
    }
}