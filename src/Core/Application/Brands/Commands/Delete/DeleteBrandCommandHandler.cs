namespace Application.Brands.Commands.Delete;

public sealed class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand>
{
    private readonly IWriteUnitOfWork _writeUOW;
    private readonly IReadUnitOfWork _readUOW;
    private readonly IMapper _map;
    private readonly ILogger<DeleteBrandCommandHandler> _log;

    public DeleteBrandCommandHandler(IWriteUnitOfWork writeUOW, IReadUnitOfWork readUOW,
        IMapper map, ILogger<DeleteBrandCommandHandler> log)
    {
        _writeUOW = writeUOW;
        _readUOW = readUOW;
        _map = map;
        _log = log;
    }

    public async Task Handle(DeleteBrandCommand request, CancellationToken ct)
    {
        var entity = await _readUOW.BrandReadRepository.GetByIdAsync(request.Id).ConfigureAwait(false);
        if(entity == null)
            throw new NotFoundException("Brand", request.Id);

        await _writeUOW.BrandWriteRepository.DeleteAsync(entity).ConfigureAwait(false);
        await _writeUOW.SaveChangesAsync(ct);
    }
}
