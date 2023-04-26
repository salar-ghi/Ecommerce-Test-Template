namespace Application.VM;

public record ProductDtos
{
    public Name Name { get; private set; } = default!;
    public Price Price { get; private set; } = default!;
    public ProductStatus ProductStatus { get; private set; }
    public string Code { get; private set; } = default!;
    public string? Description { get; private set; }
    public Size Size { get; private set; } = default!;
    public Stock Stock { get; private set; } = default!;
    public Dimensions Dimensions { get; private set; } = default!;
    public BrandId BrandId { get; private set; } = default!;
    public CategoryId CategoryId { get; private set; } = default!;
    public IEnumerable<ProductImage> _images { get; private set; } = default!;
}

public record ProductResDto : ProductDtos
{
    public string CategoryName { get; set; } = default!;
    public string BrandName { get; set; } = default!;
    public Guid Id { get; set; }
}


public record ProductReqDto : ProductDtos
{

}

public record ProductUpdateReqDto : ProductDtos
{
    public ProductId Id { get; private set; } = default!;
}


//public record ProductFilterPageReqDto
//{
//    public Guid Id { get; init; }
//    public string SearchTerm { get; set; } = default!;
//    public decimal? MinPrice { get; set; }
//    public decimal? MaxPrice { get; set; }
//    public long CategoryId { get; set; }
//    public int BrandId { get; set; }
//    public int PageIndex { get; set; }
//    public int PageSize { get; set; }
//}


