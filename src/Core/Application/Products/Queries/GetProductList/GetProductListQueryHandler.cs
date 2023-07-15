namespace Application.Products.Queries.GetProductList;

public sealed class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, PaginitionResDto<List<ProductResDto>>>
{
    private readonly IReadUnitOfWork _readUOW;
    private readonly IMapper _map;
    private readonly ILogger<GetProductListQueryHandler> _log;
    public GetProductListQueryHandler(IReadUnitOfWork readUOW, IMapper map, ILogger<GetProductListQueryHandler> log)
    {
        _readUOW = readUOW;
        _map = map;
        _log = log;
    }

    public async Task<PaginitionResDto<List<ProductResDto>>> Handle(GetProductListQuery request, CancellationToken ct)
    {
        var entityList = await _readUOW.ProductReadRepository.GetByFilterPagedAsync(request).ConfigureAwait(false);
        PaginitionResDto<List<ProductResDto>> result = new PaginitionResDto<List<ProductResDto>>
        {
            Data = _map.Map<List<ProductResDto>>(entityList.Item1),
            TotalCount = entityList.Item2,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
        };
        return result;
    }
}
