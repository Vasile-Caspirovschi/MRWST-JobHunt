using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobHunt.Infrastructure.Pagination;

public class PaginationService<TEntity, TResult>(DbContext context) : IPaginationService<TEntity, TResult> 
    where TEntity : class
{
    private const int PAGE_SIZE = 10;
    private const int PAGE_NUMBER = 1;

    private readonly DbContext _context = context;

    public async Task<PagedResult<TResult>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null)
    {
        pageNumber = pageNumber <= 0 ? PAGE_NUMBER : pageNumber;
        pageSize = pageSize <= 0 ? PAGE_SIZE : pageSize;

        var skip = (pageNumber - 1) * pageSize;
        var take = pageSize;

        var query = _context.Set<TEntity>().AsQueryable();
        if (predicate is not null)
            query.Where(predicate);

        var rowCount = await query.CountAsync();
        var pageCount = (int)Math.Ceiling((double)rowCount / pageSize);

        var result = await query.Skip(skip).Take(take).Select(selector).ToListAsync();
        return PagedResult<TResult>.Success(pageNumber, pageSize, rowCount, pageCount, result);
    }
}
