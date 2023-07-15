namespace Infrastructure.Repositories.Products;
public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
{
    public ProductWriteRepository(DataContext context) : base(context)
    {
    }

    //public async Task<Product> AddAsync(Product request)
    //{
    //    var ProductEntry = await _context.AddAsync(request); 
    //    //.Products.AddAsync(request);
    //    await _context.SaveChangesAsync();
    //    return ProductEntry.Entity;
    //}

    //public async Task DeleteAsync(Product request)
    //{
    //    _context.Products.Remove(request);
    //    await _context.SaveChangesAsync();
    //}

    //public async Task<Product> UpdateAsync(Product request)
    //{
    //    var productEntry = _context.Products.Update(request);
    //    await _context.SaveChangesAsync();
    //    return productEntry.Entity;
    //}
}
