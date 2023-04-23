namespace Application.Products.Queries.GetProductByBrand;

public sealed record GetProductByBrandQuery : ProductFilterBrandPageVM, 
    IRequest<PaginitionResDto<List<ProductResDto>>>;