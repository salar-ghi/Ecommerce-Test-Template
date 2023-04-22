namespace Infrastructure.Repositories.Brands;

public class BrandWriteRepository : IBrandWriteRepository<Brand>
{
    private readonly DataContext _context;
    public BrandWriteRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Brand> AddAsync(Brand request)
    {
        var CategoryEntry = await _context.AddAsync(request).ConfigureAwait(false);  //.Brand.AddAsync(request);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return CategoryEntry.Entity;
    }

    public async Task DeleteAsync(Brand request)
    {
        _context.Remove(request);
        await _context.SaveChangesAsync();
    }

    public async Task<Brand> UpdateAsync(Brand request)
    {
        var categoryEntry = _context.Update(request);
        await _context.SaveChangesAsync();
        return categoryEntry.Entity;
    }
}
