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

    public IProductWriteRepository ProductWriteRepository
    {
        get
        {
            return _productWriteRepository ??= new ProductWriteRepository(_context);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct);
    }

    //public async Task<bool> SaveEntitiesAsync(CancellationToken ct = default)
    //{
    //    var res = await _context.SaveChangesAsync(ct);
    //}
}
