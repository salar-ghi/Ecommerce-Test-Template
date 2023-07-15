namespace Application.Brands.Queries.GetBrand;

public sealed class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, BrandResDto>
{
    private readonly IReadUnitOfWork _readUoW;
    private readonly IMapper _map;
    private readonly ILogger<GetBrandQueryHandler> _log;

    public GetBrandQueryHandler(IReadUnitOfWork readUoW, IMapper map, ILogger<GetBrandQueryHandler> log)
    {
        _readUoW = readUoW;
        _map = map;
        _log = log;
    }

    public async Task<BrandResDto> Handle(GetBrandQuery request, CancellationToken ct)
    {
        var entity = await  _readUoW
            .BrandReadRepository
            .GetByIdAsync(request.Id)
            .ConfigureAwait(false);


        if (entity.Id.Equals(0))
            throw new NotFoundException(nameof(Brand), request.Id);

        var brandItem = _map.Map<BrandResDto>(entity);
        _log.LogInformation($"Brand : {brandItem} is successfully returned");


        return brandItem;
    }
}
