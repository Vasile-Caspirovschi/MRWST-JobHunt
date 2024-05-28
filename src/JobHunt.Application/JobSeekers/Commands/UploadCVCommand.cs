using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.JobSeekers.Commands;

public sealed record UploadCVCommand(Guid JobSeekerId, UploadedFile UploadedCV) : ICommand<CVDto>;

public class UploadCVHandler(IJobHuntDbContext dbContext, ICloudImageService cloudinaryService) : ICommandHandler<UploadCVCommand, CVDto>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;
    private readonly ICloudImageService _cloudinaryService = cloudinaryService;

    public async Task<Result<CVDto>> Handle(UploadCVCommand request, CancellationToken cancellationToken)
    {
        var jobSeeker = await _dbContext.JobSeekers
            .Include(x => x.CV)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (jobSeeker is null)
        {
            return Result.Failure<CVDto>(new Error("UploadCV.Failed", "Job seeker not found"));
        }

        var uploadResult = await _cloudinaryService.AddImageAsync(request.UploadedCV);
        if (uploadResult.Error is not null)
        {
            return Result.Failure<CVDto>(new Error("UploadCV.Failed", uploadResult.Error.Message));
        }

        if (jobSeeker.CV is null)
        {
            jobSeeker.CV = new CV();
        }
        else
        {
            var deleteResult = await _cloudinaryService.DeleteImageAsync(jobSeeker.CV.PublicId);
        }

        jobSeeker.CV.FileName = request.UploadedCV.FileName;
        jobSeeker.CV.FileUrl = uploadResult.SecureUrl.AbsoluteUri;
        jobSeeker.CV.PublicId = uploadResult.PublicId;

        _dbContext.JobSeekers.Update(jobSeeker);

        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
        {
            return new CVDto(jobSeeker.CV.FileName, jobSeeker.CV.FileUrl);
        }
        return Result.Failure<CVDto>(new Error("UploadCV.Failed", "Something went wrong when trying to upload the cv"));
    }
}