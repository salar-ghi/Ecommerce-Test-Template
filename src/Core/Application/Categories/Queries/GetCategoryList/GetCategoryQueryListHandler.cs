using Application.Brands.Queries.GetBrandList;

namespace Application.Categories.Queries.GetCategoryList;

public sealed class GetCategoryQueryListHandler : IRequestHandler<GetCategoryListQuery, PaginitionResDto<List<CategoryResDto>>>
{
    private readonly IReadUnitOfWork _readUoW;
    private readonly IMapper _map;
    private readonly ILogger<GetCategoryQueryListHandler> _log;

    public GetCategoryQueryListHandler(IReadUnitOfWork readUOW, IMapper map, ILogger<GetCategoryQueryListHandler> log)
    {
        _readUoW = readUOW;
        _map = map;
        _log = log;
    }


    public async Task<PaginitionResDto<List<CategoryResDto>>> Handle(GetCategoryListQuery request, CancellationToken ct)
    {
        var entity = await _readUoW.CategoryReadRepository.GetByFilterPagedAsync(request).ConfigureAwait(false);
        PaginitionResDto<List<CategoryResDto>> result = new PaginitionResDto<List<CategoryResDto>>
        {
            Data = _map.Map<List<CategoryResDto>>(entity.Item1),
            TotalCount = entity.Item2,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
        };
        return result;
    }
}
