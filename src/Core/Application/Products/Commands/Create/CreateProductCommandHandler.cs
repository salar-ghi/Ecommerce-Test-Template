namespace Application.Products.Commands.Create;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResDto>
{
    private readonly IWriteUnitOfWork _writeUOW;
    private readonly IMapper _map;
    private readonly ILogger<CreateProductCommandHandler> _log;
    public CreateProductCommandHandler(IWriteUnitOfWork writeUOW, IMapper map, ILogger<CreateProductCommandHandler> log)
    {
        _writeUOW = writeUOW;
        _map = map;
        _log = log;
    }


    public async Task<ProductResDto> Handle(CreateProductCommand request, CancellationToken ct)
    {
        var newProduct = _map.Map<Product>(request);
        var addProduct = await _writeUOW.ProductWriteRepository.AddAsync(newProduct).ConfigureAwait(false);

        await _writeUOW.SaveChangesAsync(ct);

        return _map.Map<ProductResDto>(addProduct);
    }
}
