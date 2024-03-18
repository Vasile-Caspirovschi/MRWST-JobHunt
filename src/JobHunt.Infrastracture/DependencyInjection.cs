using JobHunt.Application.Common.Interfaces;
using JobHunt.Infrastracture.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobHunt.Infrastracture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastracture(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IJobHuntDbContext, JobHuntDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}
