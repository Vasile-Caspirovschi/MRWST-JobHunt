using System.ComponentModel.DataAnnotations;

namespace JobHunt.Domain.Shared;
#nullable disable
public class UploadedFile
{
    [FileExtensions(Extensions = "jpg,png,pdf")]
    [StringLength(100)]
    public string FileName { get; set; }

    public long Length { get; set; }

    [MaxLength(1_048_576)] public Stream Stream { get; set; } = new MemoryStream();
}