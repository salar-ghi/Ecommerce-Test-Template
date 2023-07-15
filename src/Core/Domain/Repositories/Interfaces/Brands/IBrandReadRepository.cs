namespace Domain.Repositories.Interfaces.Brands;

public interface IBrandReadRepository : IRepository
{
    Task<Brand> GetByIdAsync(int Id);
    Task<List<Brand>> GetAllAsync();
    Task<Brand> GetAsyncNoTracking(int Id);
    Task<Tuple<List<Brand>, int>> GetByFilterPagedAsync(BrandFilterPageVM request);
}
