namespace Domain.Models;

public record CategoryViewModel
{
}

public record CategoryFilterPageVM : BaseFilterPageVM<CategoryId>
{
    public int ParentId { get; set; } = default!;
}
