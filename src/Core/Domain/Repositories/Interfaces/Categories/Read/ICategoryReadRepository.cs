namespace Domain.Repositories.Interfaces.Categories;

public interface ICategoryReadRepository : IRepository
{
    Task<Category> GetAsync(long Id);
    Task<List<Category>> GetAllAsync();
    Task<Category> GetAsyncNoTracking(long Id);
    Task<Tuple<List<Category>, int>> GetByFilterPagedAsync(CategoryFilterPageVM request);
}
