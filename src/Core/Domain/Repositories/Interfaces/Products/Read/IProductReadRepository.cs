namespace Domain.Repositories.Interfaces.Products;
public interface IProductReadRepository : IReadRepository<Product>
{
    //Task<Product> GetByIdAsync(Guid Id);
    //Task<List<Product>> GetAllAsync();
    //Task<Product> GetAsyncNoTracking(Guid Id);
    
    
    Task<List<Product>> GetByBrandAsync(int brandId);
    Task<List<Product>> GetByCategoryAsync(long categoryId);
    Task<Tuple<List<Product>, int>> GetByFilterPagedAsync(ProductFilterPageVM request);
}
