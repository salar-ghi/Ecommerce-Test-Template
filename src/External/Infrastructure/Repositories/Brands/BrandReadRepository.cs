﻿using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Brands;

public class BrandReadRepository : IBrandReadRepository
{
    private readonly DataContext _context;
    public BrandReadRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Brand>> GetAllAsync()
    {
        return await _context
            .Brands
            .AsNoTracking()
            .Include(b => b.IsRemoved == false)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<Brand?> GetAsync(BrandId Id)
    {
        return await _context
            .Brands
            .Include(x => x.IsRemoved == false)
            .FirstOrDefaultAsync(b => b.Id.Value == Id)
            .ConfigureAwait(false);
    }

    public async Task<Brand?> GetAsyncNoTracking(BrandId Id)
    {
        return await _context
            .Brands
            .AsNoTracking()
            .Include(x => x.IsRemoved == false)
            .FirstOrDefaultAsync(b => b.Id.Value == Id)
            .ConfigureAwait(false);
    }

    public async Task<Tuple<List<Brand>, int>> GetByFilterPagedAsync(BrandFilterPageVM request)
    {
        var filteredBrands = _context.Brands.AsQueryable();
        if (request.Id.Value != 0)
            filteredBrands = filteredBrands.Include(br => br.IsRemoved == false)
                .Where(b => b.Id.Value == request.Id.Value);

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            request.SearchTerm = request.SearchTerm.Trim().ToLower();
            filteredBrands = filteredBrands.Include(br => br.IsRemoved == false).Where(b =>
                                                        b.Name.ToLower().Contains(request.SearchTerm)
                                                     || b.Description.ToLower().Contains(request.SearchTerm));
        }

        int countOfFilteredBrands = filteredBrands.Count();
        filteredBrands = filteredBrands.Skip(request.PageIndex * request.PageSize)
            .Take(request.PageSize);

        return
            Tuple.Create(await filteredBrands.ToListAsync(), countOfFilteredBrands);
    }
}
