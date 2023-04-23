using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Repositories.Brands;

public class BrandWriteRepository : IBrandWriteRepository<Brand>
{
    private readonly DataContext _context;
    public BrandWriteRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Brand> AddAsync(Brand request)
    {
        var CategoryEntry = await _context.AddAsync(request).ConfigureAwait(false);  //.Brand.AddAsync(request);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return CategoryEntry.Entity;
    }

    public async Task DeleteAsync(Brand request)
    {
        //_context.Remove(request);
        var brandEntry = _context.Brands.Where(x => x.Id == request.Id && x.IsRemoved == false).FirstOrDefaultAsync();
        //_context.Update(request.IsRemoved == true);
        //_context.Brands
        //    .Where(x => x.Id == request.Id)
        //    .ExecuteUpdateAsync(b => 
        //        b.SetProperty(u => u.IsRemoved, false)
        //    );

        _context.Update(request);
        await _context.SaveChangesAsync();
    }

    public async Task<Brand> UpdateAsync(Brand request)
    {
        var brandEntry = _context.Update(request);
        await _context.SaveChangesAsync();
        return brandEntry.Entity;
    }
}
