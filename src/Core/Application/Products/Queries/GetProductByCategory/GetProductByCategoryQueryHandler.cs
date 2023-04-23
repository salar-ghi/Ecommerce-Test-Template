namespace Application.Products.Queries.GetProductByCategory;

public sealed class GetProductByCategoryQueryHandler
{
    private readonly IReadUnitOfWork _readUoW;
    private readonly IMapper _map;
    private readonly ILogger<GetProductByCategoryQueryHandler> _log;


    public GetProductByCategoryQueryHandler(IReadUnitOfWork readUoW, IMapper map, ILogger<GetProductByCategoryQueryHandler> log)
    {
        _readUoW = readUoW;
        _map = map;
        _log = log;
    }

    public async Task<PaginitionResDto<List<ProductResDto>>> Handle(GetProductByCategoryQuery request, CancellationToken ct)
    {
        var entity = await _readUoW.ProductReadRepository
            .GetByCategoryAsync(request.Id)
            .ConfigureAwait(false);

        if (entity == null)
            throw new NotFoundException(nameof(Product), request.Id);

        // ?? can covert it ????
        var ProductItem = _map.Map<PaginitionResDto<List<ProductResDto>>>(entity);

        PaginitionResDto<List<ProductResDto>> result = new PaginitionResDto<List<ProductResDto>>
        {
            Data = _map.Map<List<ProductResDto>>(entity),
            TotalCount = entity.Count,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
        };
        _log.LogInformation($"Product : {result} is successfully returned");
        return result;
    }
}
