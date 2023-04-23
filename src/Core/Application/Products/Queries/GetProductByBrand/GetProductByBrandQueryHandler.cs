namespace Application.Products.Queries.GetProductByBrand;

public sealed class GetProductByBrandQueryHandler : IRequestHandler<GetProductByBrandQuery, PaginitionResDto<List<ProductResDto>>>
{
    private readonly IReadUnitOfWork _readUoW;
    private readonly IMapper _map;
    private readonly ILogger<GetProductByBrandQueryHandler> _log;


    public GetProductByBrandQueryHandler(IReadUnitOfWork readUoW, IMapper map, ILogger<GetProductByBrandQueryHandler> log)
    {
        _readUoW = readUoW;
        _map = map;
        _log = log;
    }

    public async Task<PaginitionResDto<List<ProductResDto>>> Handle(GetProductByBrandQuery request, CancellationToken ct)
    {
        var entity = await _readUoW.ProductReadRepository
            .GetByBrandAsync(request.Id)
            .ConfigureAwait(false);

        if (entity == null)
            throw new NotFoundException(nameof(Product), request.Id);

        var ProductItem = _map.Map<ProductResDto>(entity);

        PaginitionResDto<List<ProductResDto>> result = new PaginitionResDto<List<ProductResDto>>
        {
            Data = _map.Map<List<ProductResDto>>(entity),
            TotalCount = entity.Count,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
        };
        _log.LogInformation($"Product : {ProductItem} is successfully returned");
        return result;
    }

}
