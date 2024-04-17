using CloudinaryDotNet.Actions;
using JobHunt.Domain.Shared;

namespace JobHunt.Application.Common.Interfaces;

public interface ICloudImageService
{
        Task<ImageUploadResult> AddImageAsync(UploadedImageFile file);
        Task<DeletionResult> DeleteImageAsync(string publicId);
}