namespace Domain.Repositories.Interfaces.General;

public interface IWriteRepository<TEntity> : IRepository
{
    Task AddAsync(TEntity request);
    void UpdateAsync(TEntity request);
    void DeleteAsync(TEntity request);
}
