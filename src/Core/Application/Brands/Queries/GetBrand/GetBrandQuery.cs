namespace Application.Brands.Queries.GetBrand;

public sealed record GetBrandQuery(BrandId Id) : IRequest<BrandResDto>;
