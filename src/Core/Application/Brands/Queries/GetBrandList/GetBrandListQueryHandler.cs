namespace Application.Brands.Queries.GetBrandList;

public sealed class GetBrandListQueryHandler : IRequestHandler<GetBrandListQuery, PaginitionResDto<List<BrandResDto>>>
{
    public GetBrandListQueryHandler()
    {
        
    }

    public Task<PaginitionResDto<List<BrandResDto>>> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
