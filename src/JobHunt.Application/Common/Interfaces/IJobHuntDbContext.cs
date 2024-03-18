using JobHunt.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Common.Interfaces;

public interface IJobHuntDbContext
{
    DbSet<JobPost> JobPosts { get; set; }
    DbSet<JobCategory> JobCategories { get; set; }
    DbSet<Company> Companys { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
