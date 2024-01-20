namespace Application.Common.Models;

public class PaginatedList<T>
{
    public List<T> Launches { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }

    public PaginatedList()
    {
        Launches = new List<T>();
    }
    public PaginatedList(List<T> items, int count, int pageNumber, int limit)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)limit);
        TotalCount = count;
        Launches = items.Skip((pageNumber - 1) * limit).Take(limit).ToList();
    }
}