namespace Application.Categories.Commands.Update;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IWriteUnitOfWork _writeUoW;
    private readonly IReadUnitOfWork _readUOW;
    private readonly IMapper _map;
    private readonly ILogger<UpdateCategoryCommandHandler> _log;
    public UpdateCategoryCommandHandler(IWriteUnitOfWork writeUOW, IReadUnitOfWork readUOW, IMapper map, ILogger<UpdateCategoryCommandHandler> log)
    {
        _writeUoW = writeUOW;
        _readUOW = readUOW;
        _map = map;
        _log = log;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken ct)
    {
        var entity = await _readUOW.CategoryReadRepository.GetAsyncNoTracking(request.Id).ConfigureAwait(false);
        if (entity is null)
            throw new NotFoundException(nameof(Category), request.Id);

        var updatedCategory = _map.Map<Category>(entity);
        await _writeUoW.CategoryWriteRepository.UpdateAsync(updatedCategory).ConfigureAwait(false);
        await _writeUoW.SaveChangesAsync(ct).ConfigureAwait(false);

        _log.LogInformation($"Category {entity.Id} is successfully updated.");
    }
}
