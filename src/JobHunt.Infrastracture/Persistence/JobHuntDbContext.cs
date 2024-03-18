using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Infrastracture.Persistence;

public class JobHuntDbContext : DbContext, IJobHuntDbContext
{
    public JobHuntDbContext(DbContextOptions<JobHuntDbContext> contextOptions) : base(contextOptions)
    {
    }

    public DbSet<JobPost> JobPosts { get; set; }
    public DbSet<JobCategory> JobCategories { get; set; }
    public DbSet<Company> Companys { get; set; }
}
