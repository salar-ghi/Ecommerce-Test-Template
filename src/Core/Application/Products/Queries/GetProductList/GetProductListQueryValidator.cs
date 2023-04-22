using Domain.UoW;

namespace Application.Products.Queries.GetProductList;

public sealed class GetProductListQueryValidator : IRequestHandler<GetProductListQuery, PaginitionResDto<List<ProductResDto>>>
{
    private readonly IReadUnitOfWork _readUoW;
    private readonly IMapper _map;
    private readonly ILogger<GetProductListQueryValidator> _log;

    public GetProductListQueryValidator(IReadUnitOfWork readUoW, IMapper map, ILogger<GetProductListQueryValidator> log)
    {
        _readUoW = readUoW;
        _map = map;
        _log = log;
    }


    public async Task<PaginitionResDto<List<ProductResDto>>> Handle(GetProductListQuery request, CancellationToken ct)
    {
        var productList = await _readUoW.ProductReadRepository.GetByFilterPagedAsync(request).ConfigureAwait(false);
        PaginitionResDto<List<ProductResDto>> result = new PaginitionResDto<List<ProductResDto>>
        {
            Data = _map.Map<List<ProductResDto>>(productList.Item1),
            TotalCount = productList.Item2,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize
        };

        return result;
    }
}
