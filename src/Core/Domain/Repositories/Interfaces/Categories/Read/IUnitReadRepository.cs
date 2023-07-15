namespace Domain.Repositories.Interfaces.Categories;

public interface IUnitReadRepository : IRepository
{
    Task<Unit> GetAsync(long Id);
    Task<List<Unit>> GetAllAsync();
    Task<Unit> GetAsyncNoTracking(long Id);
}
