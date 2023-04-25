namespace Application.Categories.Queries.GetCategory;

public sealed class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryResDto>
{
    private readonly IReadUnitOfWork _readUoW;
    private readonly IMapper _map;
    private readonly ILogger<GetCategoryQueryHandler> _log;

    public GetCategoryQueryHandler(IReadUnitOfWork readUoW, IMapper map, ILogger<GetCategoryQueryHandler> log)
    {
        _readUoW = readUoW;
        _map = map;
        _log = log;
    }


    public async Task<CategoryResDto> Handle(GetCategoryQuery request, CancellationToken ct)
    {
        var entity = await _readUoW
            .CategoryReadRepository
            .GetAsync(request.Id)
            .ConfigureAwait(false);


        if (entity.Id.Equals(0))
            throw new NotFoundException(nameof(Category), request.Id);

        var categoryItem = _map.Map<CategoryResDto>(entity);
        _log.LogInformation($"Category : {categoryItem} is successfully returned");


        return categoryItem;
    }
}
