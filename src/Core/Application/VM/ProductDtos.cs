using Domain.Aggregates.ProductAggregate;

namespace Application.VM;

public record ProductDtos
{
    public string Name { get; private set; } = default!;
    public ProductStatus ProductStatus { get; private set; }
    public string Code { get; private set; } = default!;
    public string? Description { get; private set; }
    public Stock Stock { get; private set; } = default!;
    public Dimensions Dimensions { get; private set; } = default!;
    public int BrandId { get; private set; } = default!;
    public long CategoryId { get; private set; } = default!;
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
    public Guid Id { get; private set; } = default!;
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


