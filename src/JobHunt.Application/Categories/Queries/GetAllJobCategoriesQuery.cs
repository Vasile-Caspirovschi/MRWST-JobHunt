using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Categories.Queries;

public sealed record GetAllJobCategoriesQuery() : IQuery<IEnumerable<string>>;

public class GetAllJobCategoriesHanlder(IJobHuntDbContext dbContext) : IQueryHandler<GetAllJobCategoriesQuery, IEnumerable<string>>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result<IEnumerable<string>>> Handle(GetAllJobCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _dbContext.JobCategories.Select(category => category.Title).ToListAsync();
        return categories;
    }
}