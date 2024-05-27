using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.JobSeekers.Commands;

public sealed record DeleteCVCommand(Guid JobSeekerId) : ICommand;

public class DeletCVHandler(IJobHuntDbContext dbContext, ICloudImageService cloudinaryService) : ICommandHandler<DeleteCVCommand>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;
    private readonly ICloudImageService _cloudinaryService = cloudinaryService;

    public async Task<Result> Handle(DeleteCVCommand request, CancellationToken cancellationToken)
    {
        var jobSeeker = await _dbContext.JobSeekers
            .Include(x => x.CV)
            .FirstOrDefaultAsync(x => x.Id == request.JobSeekerId);

        if (jobSeeker is null)
        {
            return Result.Failure(new Error("DeleteCV.Failed", "Could not found job seeker"));
        }

        if (jobSeeker.CV is null)
        {
            return Result.Failure(new Error("DeleteCV.Failed", "Job seeker has not uploaded a CV"));
        }

        var deleteResult = await _cloudinaryService.DeleteImageAsync(jobSeeker.CV.PublicId);
        if (deleteResult.Error is not null)
            return Result.Failure(new Error("DeleteCV.Failed", deleteResult.Error.Message));

        var context = _dbContext as DbContext;
        context.Set<CV>().Remove(jobSeeker.CV);

        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
        {
            return Result.Success();
        }
        return Result.Failure<CVDto>(new Error("UploadCV.Failed", "Something went wrong when trying to delete the cv"));
    }
}