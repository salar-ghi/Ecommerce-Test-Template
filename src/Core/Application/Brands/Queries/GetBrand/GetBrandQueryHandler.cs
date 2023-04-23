namespace Application.Brands.Queries.GetBrand;

public sealed class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, BrandResDto>
{
    public GetBrandQueryHandler()
    {
        
    }

    public Task<BrandResDto> Handle(GetBrandQuery request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
