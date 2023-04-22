namespace Domain.Entities.Products;

public interface IProductReadRepository : IRepository
{
    Task<Product> GetAsync(ProductId Id);
    Task<List<Product>> GetAllAsync();
    Task<Product> GetAsyncNoTracking(ProductId Id);
    Task<Tuple<List<Product>, int>> GetByFilterPagedAsync(ProductFilterPageVM request);


    Task<List<Product>> GetByBrandAsync(BrandId brandId);
    Task<List<Product>> GetByCategoryAsync(CategoryId categoryId);
}
