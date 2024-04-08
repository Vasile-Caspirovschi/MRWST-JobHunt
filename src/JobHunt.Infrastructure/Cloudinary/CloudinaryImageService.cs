using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Shared;
using Microsoft.Extensions.Options;

namespace JobHunt.Infrastructure.Cloudinary;

public class CloudinaryImageService : ICloudImageService
{
    private readonly CloudinaryDotNet.Cloudinary _cloudinary;

    public CloudinaryImageService(IOptions<CloudinarySettings> config)
    {
        var account = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
        _cloudinary = new CloudinaryDotNet.Cloudinary(account);
    }

    public async Task<ImageUploadResult> AddImageAsync(UploadedImageFile file)
    {
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, file.Stream),
            Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
        };
        return await _cloudinary.UploadAsync(uploadParams);
    }

    public async Task<DeletionResult> DeleteImageAsync(string publicId)
    {
        var deleteParams = new DeletionParams(publicId);
        var deletionResult = await _cloudinary.DestroyAsync(deleteParams);
        return deletionResult;
    }
}