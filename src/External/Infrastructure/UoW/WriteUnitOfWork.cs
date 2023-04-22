namespace Infrastructure.UoW;

public class WriteUnitOfWork : IWriteUnitOfWork
{
    private readonly DataContext _context;

    private BrandWriteRepository _brandWriteRepository;
    private CategoryWriteRepository _categoryWriteRepository;
    private ProductWriteRepository _productWriteRepository;

    public WriteUnitOfWork(DataContext Context)
    {
        _context = Context;
    }

    public IBrandWriteRepository<Brand> BrandWriteRepository
    {
        get
        {
            return _brandWriteRepository ??= new BrandWriteRepository(_context);
        }
    }

    public ICategoryWriteRepository<Category> CategoryWriteRepository
    {
        get
        {
            return _categoryWriteRepository ??= new CategoryWriteRepository(_context);
        }
    }

    public IProductWriteRepository<Product> ProductWriteRepository
    {
        get
        {
            return _productWriteRepository ??= new ProductWriteRepository(_context);
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveEntitiesAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}
