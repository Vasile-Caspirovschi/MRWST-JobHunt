using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobHunt.Infrastructure.Pagination;

public class PaginationService<TResult> : IPaginationService<TResult>
{
    private const int PAGE_SIZE = 10;
    private const int PAGE_NUMBER = 1;

    public async Task<PagedResult<TResult>> GetPagedAsync(PaginationParams paginationParams, IQueryable<TResult> query)
    {
        var pageNumber = paginationParams.PageNumber <= 0 ? PAGE_NUMBER : paginationParams.PageNumber;
        var pageSize = paginationParams.PageSize <= 0 ? PAGE_SIZE : paginationParams.PageSize;

        var skip = (pageNumber - 1) * pageSize;
        var take = pageSize;

        var totalItems = await query.CountAsync();
        var pageCount = (int)Math.Ceiling((double)totalItems / pageSize);
        pageCount = pageCount == 0 ? 1 : pageCount;

        var result = await query.Skip(skip).Take(take).ToListAsync();
        return PagedResult<TResult>.Success(pageNumber, pageSize, totalItems, pageCount, result);
    }
}
