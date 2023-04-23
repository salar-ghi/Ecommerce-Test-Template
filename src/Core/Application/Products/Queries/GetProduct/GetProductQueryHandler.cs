namespace Application.Products.Queries.GetProduct;

public sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResDto>
{
    private readonly IReadUnitOfWork _readUoW;
    private readonly IMapper _map;
    private readonly ILogger<GetProductQueryHandler> _log;


    public GetProductQueryHandler(IReadUnitOfWork readUoW, IMapper map, ILogger<GetProductQueryHandler> log)
    {
        _readUoW = readUoW;
        _map = map;
        _log = log;
    }


    public async Task<ProductResDto> Handle(GetProductQuery request, CancellationToken ct)
    {
        var entity = await _readUoW.ProductReadRepository
            .GetAsync(request.Id)
            .ConfigureAwait(false);

        if(entity.Id == Guid.Empty)
            throw new NotFoundException(nameof(Product), request.Id);


        var ProductItem = _map.Map<ProductResDto>(entity);
        _log.LogInformation($"Product : { ProductItem } is successfully returned");

        return ProductItem;
    }
}
