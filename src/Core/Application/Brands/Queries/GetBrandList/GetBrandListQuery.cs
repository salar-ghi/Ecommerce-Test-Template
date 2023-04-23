namespace Application.Brands.Queries.GetBrandList;

public sealed record GetBrandListQuery
    : BrandFilterPageVM, IRequest<PaginitionResDto<List<BrandResDto>>>;
