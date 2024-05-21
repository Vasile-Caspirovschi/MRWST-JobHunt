using JobHunt.Domain.Shared;
using System.Linq.Expressions;

namespace JobHunt.Application.Common.Interfaces;

public interface IPaginationService<TResult>
{
    /// <summary>
    /// Returns a PagedResult<TResult>
    /// </summary>
    Task<PagedResult<TResult>> GetPagedAsync(PaginationParams paginationParams, IQueryable<TResult> query);
}
