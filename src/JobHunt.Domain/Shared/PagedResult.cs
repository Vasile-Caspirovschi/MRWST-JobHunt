namespace JobHunt.Domain.Shared;

/// <summary>
/// If success returns an IEnumerable of TValue through Value member
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class PagedResult<TValue> : Result<IEnumerable<TValue>>
{
    public int PageNumber { get; }
    public int PageSize { get; }
    public int RowCount { get; }
    public int PageCount { get; }

    protected internal PagedResult(bool isSuccess, Error error, int pageNumber,
        int pageSize, int rowCount, int pageCount, IEnumerable<TValue> value) : base(value, isSuccess, error)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        RowCount = rowCount;
        PageCount = pageCount;
    }

    public static PagedResult<TValue> Success(int pageNumber, int pageSize, int rowCount, int pageCount, IEnumerable<TValue> results) =>
       new PagedResult<TValue>(true, Error.None, pageNumber, pageSize, rowCount, pageCount, results);
}
