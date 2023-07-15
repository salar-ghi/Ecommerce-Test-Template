namespace Application.Brands.Queries.GetBrand;

public sealed record GetBrandQuery(int Id) : IRequest<BrandResDto>;
