namespace Application.Brands.Commands.Create;

public sealed class AddBrandCommandHandler : IRequestHandler<AddBrandCommand, BrandResDto>
{
    private readonly IWriteUnitOfWork _writeUOW;
    private readonly IMapper _map;
    private readonly ILogger<AddBrandCommandHandler> _log;

    public AddBrandCommandHandler(IWriteUnitOfWork writeUOW, IMapper map, ILogger<AddBrandCommandHandler> log)
    {
        _writeUOW = writeUOW;
        _map = map;
        _log = log;
    }

    public async Task<BrandResDto> Handle(AddBrandCommand request, CancellationToken ct)
    {
        //var entity = new Brand
        //{
        //    Name = request.Name,
        //    Description = request.Description,
        //};

        var entity = _map.Map<Brand>(request);
        var addBrand = await _writeUOW.BrandWriteRepository.AddAsync(entity).ConfigureAwait(false);
        await _writeUOW.SaveChangesAsync(ct).ConfigureAwait(false);

        _log.LogInformation($"Brand {entity.Id} is successfully added");

        return _map.Map<BrandResDto>(addBrand);
    }
}
