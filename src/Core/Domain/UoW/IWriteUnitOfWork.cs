namespace Domain.UoW;

public interface IWriteUnitOfWork : IUnitOfWork, IDisposable
{
    public IBrandWriteRepository<Brand> BrandWriteRepository { get; }
    public ICategoryWriteRepository<Category> CategoryWriteRepository { get; }
    public IProductWriteRepository ProductWriteRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken ct = default(CancellationToken));
    //Task<bool> SaveEntitiesAsync(CancellationToken ct = default(CancellationToken));
}
