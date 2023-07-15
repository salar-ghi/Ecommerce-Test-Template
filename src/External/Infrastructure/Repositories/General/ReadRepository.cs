using System.Linq.Expressions;

namespace Infrastructure.Repositories.General;

public class ReadRepository<T> : IReadRepository<T> where T : class
{
    protected readonly DataContext _context;
    public ReadRepository(DataContext context)
    {
        _context = context;
    }
   
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync().ConfigureAwait(false);
    }

    public async Task<T> GetAsyncNoTracking<Tin>(Tin Id)
    {
        return await _context.Set<T>().FindAsync(Id).ConfigureAwait(false);
    }

    public async Task<T> GetByIdAsync<Tin>(Tin Id)
    {
        return await _context.Set<T>().FindAsync(Id).ConfigureAwait(false);
    }

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().Where(expression).ToListAsync();
    }
}
