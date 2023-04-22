namespace Domain.Entities.Brands;

public interface IBrandReadRepository : IRepository
{
    Task<Brand> GetAsync(BrandId Id);
    Task<List<Brand>> GetAllAsync();
    Task<Brand> GetAsyncNoTracking(BrandId Id);
    Task<Tuple<List<Brand>, int>> GetByFilterPagedAsync(BrandFilterPageVM request);
}
