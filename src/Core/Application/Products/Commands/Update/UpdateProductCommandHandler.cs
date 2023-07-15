namespace Application.Products.Commands.Update;

public sealed record UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IWriteUnitOfWork _writeUOW;
    private readonly IReadUnitOfWork _readUOW;
    private readonly IMapper _map;
    private readonly ILogger<UpdateProductCommandHandler> _log;
    public UpdateProductCommandHandler(IWriteUnitOfWork writeUOW, IReadUnitOfWork readUOW,
        IMapper map, ILogger<UpdateProductCommandHandler> log)
    {
        _writeUOW = writeUOW;
        _readUOW = readUOW;
        _map = map;
        _log = log;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken ct)
    {
        var entity = await _readUOW.ProductReadRepository.GetByIdAsync(request.Id).ConfigureAwait(false);
        if (entity is null)
            throw new NotFoundException(nameof(Product), request.Id);

        var updatedProduct = _map.Map<Product>(entity);
        await _writeUOW.ProductWriteRepository.DeleteAsync(updatedProduct).ConfigureAwait(false);
        await _writeUOW.SaveChangesAsync(ct).ConfigureAwait(false);

        _log.LogInformation($"Product {entity.Id} is successfully updated");

    }
}
