namespace Application.Brands.Commands.Update;

public sealed class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand>
{
    private readonly IWriteUnitOfWork _writeUOW;
    private readonly IReadUnitOfWork _readUOW;
    private readonly IMapper _map;
    private readonly ILogger<UpdateBrandCommandHandler> _log;
    public UpdateBrandCommandHandler(IWriteUnitOfWork writeUOW, IReadUnitOfWork readUOW,
        IMapper map, ILogger<UpdateBrandCommandHandler> log)
    {
        _writeUOW = writeUOW;
        _readUOW = readUOW;
        _map = map;
        _log = log;
    }


    public async Task Handle(UpdateBrandCommand request, CancellationToken ct)
    {
        var entity = await _readUOW.BrandReadRepository.GetAsync(request.Id).ConfigureAwait(false);
        if (entity is null)
            throw new NotFoundException(nameof(Brand), request.Id);

        var updatedBrand = _map.Map<Brand>(entity);
        await _writeUOW.BrandWriteRepository.UpdateAsync(updatedBrand).ConfigureAwait(false);
        _log.LogInformation($"Brand {entity.Id} is successfully updated.");
    }
}
