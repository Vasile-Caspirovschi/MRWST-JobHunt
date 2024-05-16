namespace JobHunt.Presentation.Models;

public class PaginationViewModel
{
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public int PageSize { get; } = 10;
    public int CurrentPage { get; set; } = 1;

    public int Step { get; } = 5;
    public int ItemsAroundCurrentPage = 2;

    public PaginationViewModel(int totalPages, int totalItems, int pageSize, int currentPage)
    {
        TotalPages = totalPages;
        TotalItems = totalItems;
        PageSize = pageSize;
        CurrentPage = currentPage;
    }

    public int FromPage
    {
        get => ((CurrentPage - ItemsAroundCurrentPage) > 1) ? CurrentPage - ItemsAroundCurrentPage : 1;
    }
    public int ToPage
    {
        get => TotalPages > Step ? CurrentPage + ItemsAroundCurrentPage : TotalPages;
    }
}
