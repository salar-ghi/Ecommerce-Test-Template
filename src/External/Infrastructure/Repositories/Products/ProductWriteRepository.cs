namespace Infrastructure.Repositories.Products;
public class ProductWriteRepository : IProductWriteRepository<Product>
{
    private readonly DataContext _context;

    public ProductWriteRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Product> AddAsync(Product request)
    {
        var ProductEntry = await _context.AddAsync(request);  //.Products.AddAsync(request);
        await _context.SaveChangesAsync();
        return ProductEntry.Entity;
    }

    public async Task DeleteAsync(Product request)
    {
        _context.Products.Remove(request);
        await _context.SaveChangesAsync();
    }

    public async Task<Product> UpdateAsync(Product request)
    {
        var productEntry = _context.Products.Update(request);
        await _context.SaveChangesAsync();
        return productEntry.Entity;
    }
}
