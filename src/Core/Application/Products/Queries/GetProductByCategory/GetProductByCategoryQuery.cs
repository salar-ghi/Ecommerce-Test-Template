namespace Application.Products.Queries.GetProductByCategory;

public sealed record GetProductByCategoryQuery : ProductFilterCategoryPageVM, IRequest<PaginitionResDto<List<ProductResDto>>>;