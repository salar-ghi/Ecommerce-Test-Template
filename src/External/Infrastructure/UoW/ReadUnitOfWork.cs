namespace Infrastructure.UoW;
public class ReadUnitOfWork : IReadUnitOfWork
{
    private readonly DataContext _context;


    private BrandReadRepository _brandReadRepository;
    private CategoryReadRepository _categoryReadRepository;
    private ProductReadRepository _productReadRepository;
    public ReadUnitOfWork(DataContext Context)
    {
        _context = Context;
    }

    public ICategoryReadRepository CategoryReadRepository
    {
        get 
        { 
            return _categoryReadRepository ??= new CategoryReadRepository(_context);
        }
    }

    public IBrandReadRepository BrandReadRepository
    {
        get
        {
            return _brandReadRepository ??= new BrandReadRepository(_context);
        }
    }

    public IProductReadRepository ProductReadRepository
    {
        get
        {
            return _productReadRepository ??= new ProductReadRepository(_context);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }


}
