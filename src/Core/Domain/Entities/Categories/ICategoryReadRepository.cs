namespace Domain.Entities.Categories;

public interface ICategoryReadRepository : IRepository 
{
    Task<Category> GetAsync(CategoryId Id);
    Task<List<Category>> GetAllAsync();
    Task<Category> GetAsyncNoTracking(CategoryId Id);
    Task<Tuple<List<Category>, int>> GetByFilterPagedAsync(CategoryFilterPageVM request);
}
