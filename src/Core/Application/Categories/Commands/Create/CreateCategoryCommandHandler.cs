namespace Application.Categories.Commands.Create;

public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResDto>
{
    private readonly IWriteUnitOfWork _writeUOW;
    private readonly IMapper _map;
    private readonly ILogger<CreateCategoryCommandHandler> _log;
    public CreateCategoryCommandHandler(IWriteUnitOfWork writeUOW, IMapper map, ILogger<CreateCategoryCommandHandler> log)
    {
        _writeUOW = writeUOW;
        _map = map;
        _log = log;
    }

    public async Task<CategoryResDto> Handle(CreateCategoryCommand request, CancellationToken ct)
    {
        var entity = _map.Map<Category>(request);
        var addedCategory = await _writeUOW.CategoryWriteRepository.AddAsync(entity).ConfigureAwait(false);
        _log.LogInformation($"Product {addedCategory.Id} is successfully created");

        await _writeUOW.SaveChangesAsync(ct);

        return _map.Map<CategoryResDto>(addedCategory);
    }
}
