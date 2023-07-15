using Domain.Base;

namespace Infrastructure.Repositories.General;

public class WriteRepository<T> : IWriteRepository<T> where T : class
{

    protected readonly DataContext _context;
    public WriteRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T request)
    {
        var res = await _context.Set<T>().AddAsync(request);
        //return res.Entity;
    }

    public void DeleteAsync(T request)
    {
        //var entity = _context.Set<T>().FindAsync(request);
        //_context.Set<T>().Remove(request);
        _context.Set<T>().Update(request);
    }

    public void UpdateAsync(T request)
    {
        _context.Set<T>().Update(request);
    }
}
