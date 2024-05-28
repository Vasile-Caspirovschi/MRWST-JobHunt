using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Domain.Entities;

[Table("CVs")]
public class CV
{
    public Guid Id { get; set; }
    public string FileUrl { get; set; } = string.Empty;
    public string PublicId { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
}
