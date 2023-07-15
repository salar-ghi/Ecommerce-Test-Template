namespace Domain.Repositories.Interfaces.Products;

public interface IProductImageReadRepository : IRepository
{
    Task<ProductImage> GetByIdAsync(long Id);
    Task<List<ProductImage>> GetAllAsync();
    Task<ProductImage> GetAsyncNoTracking(long Id);
    Task<Tuple<List<ProductImage>, int>> GetByFilterPagedAsync(ProductFilterPageVM request);
    
    
    
    Task<List<ProductImage>> GetByProductIdAsync(Guid productId);
}
