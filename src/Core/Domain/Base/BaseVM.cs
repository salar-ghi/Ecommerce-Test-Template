namespace Domain.Base;

public class BaseVM<T>
{
    public T Id { get; private set; }
}


public abstract record BaseFilterPageVM<T>
{
    public T Id { get; set; }
    public string SearchTerm { get; set; } = default!;
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}


