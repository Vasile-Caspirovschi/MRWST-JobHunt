using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Infrastructure.Persistence;

public class JobHuntDbContext(DbContextOptions<JobHuntDbContext> contextOptions) : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>(contextOptions), IJobHuntDbContext
{
    public DbSet<JobPost> JobPosts { get; set; }
    public DbSet<JobCategory> JobCategories { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
    public DbSet<JobSeeker> JobSeekers { get; set; }
    public DbSet<Employer> Employers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AppUser>().ToTable("Users");
        modelBuilder.Entity<JobSeeker>().ToTable("JobSeekers");
        modelBuilder.Entity<Employer>().ToTable("Employers");
    }

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        await Database.MigrateAsync(cancellationToken);
    }
}
