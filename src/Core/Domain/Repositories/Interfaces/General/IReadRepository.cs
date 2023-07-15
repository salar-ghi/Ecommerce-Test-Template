using System.Linq.Expressions;

namespace Domain.Repositories.Interfaces.General;

public interface IReadRepository<T>
    where T : class
{
    Task<T> GetByIdAsync<Tin>(Tin Id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsyncNoTracking<Tin>(Tin Id);
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    //Task<Tuple<List<TOut>, int>> GetByFilterPagedAsync(ProductFilterPageVM request);


}
