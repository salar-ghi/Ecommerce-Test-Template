namespace Infrastructure.Repositories.Categories;

public class CategoryWriteRepository : ICategoryWriteRepository<Category>
{
    private readonly DataContext _context;
    public CategoryWriteRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Category> AddAsync(Category request)
    {
        var CategoryEntry = await _context.Categories.AddAsync(request).ConfigureAwait(false);  //.Category.AddAsync(request);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return CategoryEntry.Entity;
    }

    public async Task DeleteAsync(Category request)
    {
        _context.Remove(request);
        await _context.SaveChangesAsync();
    }

    public async Task<Category> UpdateAsync(Category request)
    {
        var categoryEntry = _context.Update(request);
        await _context.SaveChangesAsync();
        return categoryEntry.Entity;
    }
}
