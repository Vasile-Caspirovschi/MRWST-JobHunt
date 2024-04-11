using JobHunt.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Common.Interfaces;

public interface IJobHuntDbContext : IDisposable
{
    DbSet<JobPost> JobPosts { get; set; }
    DbSet<JobCategory> JobCategories { get; set; }
    DbSet<Company> Companies { get; set; }
    DbSet<AppUser> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task MigrateAsync(CancellationToken cancellationToken);
}
