namespace Application.Products.Queries.GetProductList;

public sealed record GetProductListQuery : ProductFilterPageVM, IRequest<PaginitionResDto<List<ProductResDto>>>
{
}
