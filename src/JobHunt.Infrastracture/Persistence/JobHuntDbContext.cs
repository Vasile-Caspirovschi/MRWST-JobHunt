using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Infrastracture.Persistence;

public class JobHuntDbContext(DbContextOptions<JobHuntDbContext> contextOptions) : IdentityDbContext<AppUser, IdentityRole, string>(contextOptions), IJobHuntDbContext
{
    public DbSet<JobPost> JobPosts { get; set; }
    public DbSet<JobCategory> JobCategories { get; set; }
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>().HasOne(c => c.CompanyRepresentative).WithOne()
            .HasForeignKey<Company>(c => c.CompanyRepresentativeId);
        base.OnModelCreating(modelBuilder);
    }


    public void Migrate()
    {
        Database.Migrate();
    }
}
