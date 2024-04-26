using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobHunt.Infrastructure.Pagination;

public class PaginationService<TEntity, TResult>(IJobHuntDbContext context) : IPaginationService<TEntity, TResult>
    where TEntity : class
{
    private const int PAGE_SIZE = 10;
    private const int PAGE_NUMBER = 1;

    private readonly DbContext _context = context as DbContext;

    public async Task<PagedResult<TResult>> GetPagedAsync(PaginationParams paginationParams,
        Expression<Func<TEntity, TResult>> selector,
        IEnumerable<Expression<Func<TEntity, object>>>? includes = null,
        Expression<Func<TEntity, bool>>? predicate = null)
    {
        var pageNumber = paginationParams.PageNumber <= 0 ? PAGE_NUMBER : paginationParams.PageNumber;
        var pageSize = paginationParams.PageSize <= 0 ? PAGE_SIZE : paginationParams.PageSize;

        var skip = (pageNumber - 1) * pageSize;
        var take = pageSize;

        var query = _context.Set<TEntity>().AsQueryable();
        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);
        //if (predicate is not null)
        //    //query = query.Where(predicate);

        var rowCount = await query.CountAsync();
        var pageCount = (int)Math.Ceiling((double)rowCount / pageSize);
        pageCount = pageCount == 0 ? 1 : pageCount;

        var result = await query.Skip(skip).Take(take).Select(selector).ToListAsync();
        return PagedResult<TResult>.Success(pageNumber, pageSize, rowCount, pageCount, result);
    }
}
