namespace Domain.Interfaces;

public interface IWriteRepository<TEntity> : IRepository
{
    Task<TEntity> AddAsync(TEntity request);
    Task<TEntity> UpdateAsync(TEntity request);
    Task DeleteAsync(TEntity request);
}
