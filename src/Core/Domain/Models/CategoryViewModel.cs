namespace Domain.Models;

public record CategoryViewModel
{
}

public record CategoryFilterPageVM : BaseFilterPageVM<long>
{
    public long ParentId { get; set; } = default!;
}
