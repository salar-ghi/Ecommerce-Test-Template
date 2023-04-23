namespace Domain.Models;

public class ProductViewModel
{
}

public record ProductFilterPageVM : BaseFilterPageVM<ProductId>
{
    //public Guid Id { get; init; }
    //public string SearchTerm { get; set; } = default!;
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public long CategoryId { get; set; }
    public int BrandId { get; set; }
    //public int PageIndex { get; set; }
    //public int PageSize { get; set; }
}

public record ProductFilterBrandPageVM : BaseFilterPageVM<BrandId>
{
}

public record ProductFilterCategoryPageVM : BaseFilterPageVM<CategoryId>
{
}
