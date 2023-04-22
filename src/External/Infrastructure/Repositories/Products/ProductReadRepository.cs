namespace Infrastructure.Repositories.Products;

public class ProductReadRepository : IProductReadRepository
{
    private readonly DataContext _context;
    public ProductReadRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context
            .Products
            .AsNoTracking()
            .Include(x => x.IsRemoved == false)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<Product?> GetAsync(ProductId Id)
    {
        return await _context
            .Products
            .Include(pr => pr.IsRemoved == false && pr.Stock.Available > 0)
            .FirstOrDefaultAsync(x => x.Id == Id)
            .ConfigureAwait(false);
    }

    public async Task<Product?> GetAsyncNoTracking(ProductId Id)
    {
        return await _context
            .Products
            .AsNoTracking()
            .Include(pr => pr.IsRemoved == false && pr.Stock.Available > 0)
            .FirstOrDefaultAsync(p => p.Id == Id)
            .ConfigureAwait(false);
    }

    public async Task<List<Product>> GetByBrandAsync(BrandId brandId)
    {
        return await _context
            .Products
            .AsNoTracking()
            //.Include(pr => pr.IsRemoved == false && pr.Stock.Available > 0)
            .Include(pr => pr.IsRemoved == false)
            .Where(b => b.BrandId == brandId)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<List<Product>> GetByCategoryAsync(CategoryId categoryId)
    {
        return await _context
            .Products
            .AsNoTracking()
            .Include(pr => pr.IsRemoved == false)
            .Where(x => x.CategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<Tuple<List<Product>, int>> GetByFilterPagedAsync(ProductFilterPageVM request)
    {
        var filteredProducts = _context.Products.AsQueryable();

        if (request.Id != Guid.Empty)
            filteredProducts = filteredProducts.Include(pr => pr.IsRemoved == false)
                .Where(p => p.Id == request.Id);

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            request.SearchTerm = request.SearchTerm.Trim().ToLower();
            filteredProducts = filteredProducts.Include(pr => pr.IsRemoved == false)
                                                              .Where(p => p.Name.Value.ToLower().Contains(request.SearchTerm)
                                                           || p.Description.ToLower().Contains(request.SearchTerm)
                                                           || p.Code.ToLower().Contains(request.SearchTerm));
        }

        if (request.MinPrice != null)
            filteredProducts = filteredProducts.Include(pr => pr.IsRemoved == false)
                .Where(p => p.Price.Value >= request.MinPrice);

        if (request.MaxPrice != null)
            filteredProducts = filteredProducts.Include(pr => pr.IsRemoved == false)
                .Where(p => p.Price.Value >= request.MaxPrice);

        if (request.CategoryId != 0)
            filteredProducts = filteredProducts.Include(pr => pr.IsRemoved == false)
                .Where(p => p.CategoryId.Value == request.CategoryId);

        if (request.BrandId != 0)
            filteredProducts = filteredProducts.Include(pr => pr.IsRemoved == false)
                .Where(p => p.BrandId == request.BrandId);

        int countOfFilteredProducts = filteredProducts.Count();
        filteredProducts = filteredProducts.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);

        return 
            Tuple.Create(await filteredProducts.ToListAsync(), countOfFilteredProducts);

    }

}
