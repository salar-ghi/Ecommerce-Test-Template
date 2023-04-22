namespace Application.VM;

public class PaginitionResDto<T>
{
    public T Data { get; set; } = default!;
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int PageIndex { get; set; }
}
