namespace Infrastructure.Repositories.Categories;

public class CategoryReadRepository : ICategoryReadRepository
{
    private readonly DataContext _context;
    public CategoryReadRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _context
                    .Categories
                    .AsNoTracking()
                    .Include(c => c.IsActive == ActivationStatus.Active && c.IsRemoved == false)
                    .ToListAsync()
                    .ConfigureAwait(false);
    }

    public async Task<Category?> GetAsync(CategoryId Id)
    {
        return await _context
                    .Categories
                    .Include(c => c.IsRemoved == false)
                    .FirstOrDefaultAsync(x => x.Id == Id)
                    .ConfigureAwait(false);
    }

    public async Task<Category?> GetAsyncNoTracking(CategoryId Id)
    {
        return await _context
                    .Categories
                    .AsNoTracking()
                    .Include(c => c.IsRemoved == false)
                    .FirstOrDefaultAsync(p => p.Id == Id)
                    .ConfigureAwait(false);
    }

    public async Task<Tuple<List<Category>, int>> GetByFilterPagedAsync(CategoryFilterPageVM request)
    {
        var filteredCategories = _context.Categories.AsQueryable();
        if(request.Id != 0 )
            filteredCategories = filteredCategories.Include(c => c.IsRemoved == false).Where(c => c.Id == request.Id);

        if (request.ParentId != 0)
            filteredCategories = filteredCategories.Include(pr => pr.IsRemoved == false).Where(c => c.ParentId == request.ParentId);

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            request.SearchTerm = request.SearchTerm.Trim().ToLower();
            filteredCategories = filteredCategories.Include(pr => pr.IsRemoved == false).Where(c =>
                                                            c.Name.ToLower().Contains(request.SearchTerm)
                                                         || c.Description.ToLower().Contains(request.SearchTerm)
                                                         || c.Code.ToLower().Contains(request.SearchTerm));
        }

        int countOfFilteredCategories = filteredCategories.Count();
        filteredCategories = filteredCategories.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);

        return
            Tuple.Create(await filteredCategories.ToListAsync(), countOfFilteredCategories);

    }
}
