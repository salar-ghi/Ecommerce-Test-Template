namespace Application.Categories.Commands.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{

    private readonly IWriteUnitOfWork _writeUoW;
    private readonly IReadUnitOfWork _readUOW;
    private readonly IMapper _map;
    private readonly ILogger<DeleteCategoryCommandHandler> _log;
    public DeleteCategoryCommandHandler(IWriteUnitOfWork writeUOW, IReadUnitOfWork readUOW, IMapper map, ILogger<DeleteCategoryCommandHandler> log)
    {
        _writeUoW = writeUOW;
        _readUOW = readUOW;
        _map = map;
        _log = log;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken ct)
    {
        var entity = await _readUOW.CategoryReadRepository.GetAsync(request.Id).ConfigureAwait(false);
        if (entity is null)
            throw new NotFoundException("Category", request.Id);

        _writeUoW.CategoryWriteRepository.DeleteAsync(entity); //.ConfigureAwait(false);
        await _writeUoW.SaveChangesAsync(ct).ConfigureAwait(false);
        _log.LogInformation($"Category {entity.Id} is successfully removed.");
    }
}
