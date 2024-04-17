using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Domain.Entities;

[Table("Images")]
public class Image
{
    public Guid Id { get; set; }
    public required string ImageUrl { get; set; }
    public required string PublicId { get; set; }
    public Guid CompanyId { get; set; }
    public required Company Company { get; set; }
}