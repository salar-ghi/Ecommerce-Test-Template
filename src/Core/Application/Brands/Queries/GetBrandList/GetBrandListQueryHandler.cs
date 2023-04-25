namespace Application.Brands.Queries.GetBrandList;

public sealed class GetBrandListQueryHandler : IRequestHandler<GetBrandListQuery, PaginitionResDto<List<BrandResDto>>>
{
    private readonly IReadUnitOfWork _readUoW;
    private readonly IMapper _map;
    private readonly ILogger<GetBrandListQueryHandler> _log;

    public GetBrandListQueryHandler(IReadUnitOfWork readUOW, IMapper map, ILogger<GetBrandListQueryHandler> log)
    {
        _readUoW = readUOW;
        _map = map;
        _log = log;
    }

    public async Task<PaginitionResDto<List<BrandResDto>>> Handle(GetBrandListQuery request, CancellationToken ct)
    {
        var entity = await _readUoW.BrandReadRepository.GetByFilterPagedAsync(request).ConfigureAwait(false);
        PaginitionResDto<List<BrandResDto>> result = new PaginitionResDto<List<BrandResDto>>
        {
            Data = _map.Map<List<BrandResDto>>(entity.Item1),
            TotalCount = entity.Item2,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
        };
        return result;
    }
}
