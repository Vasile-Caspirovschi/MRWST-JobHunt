using CloudinaryDotNet.Actions;
using JobHunt.Domain.Shared;
using System.Linq.Expressions;

namespace JobHunt.Application.Common.Interfaces;

public interface IPaginationService<TEntity, TResult> where TEntity : class
{
    /// <summary>
    /// Returns a PagedResult mapping at the same time form TEntity to TResult using specified selector
    /// </summary>
    /// <param name="selector">Used for mapping from source to result</param>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="predicate">Used for filtering</param>
    /// <returns></returns>
    Task<PagedResult<TResult>> GetPagedAsync(int pageNumber, int pageSize,
        Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null);
}
