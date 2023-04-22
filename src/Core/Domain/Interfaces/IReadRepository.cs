namespace Domain.Interfaces;

//public interface IReadRepository<TEntity> : IRepository<TEntity>
public interface IReadRepository<TRequest, TResponse> : IRepository
{
    // GetById
    Task<TResponse> GetAsync(TRequest Id);
    Task<List<TResponse>> GetAllAsync();
    Task<TResponse> GetAsyncNoTracking(TRequest Id);
    Task<Tuple<List<TResponse>, int>> GetByFilterPagedAsync(TRequest request);
}
