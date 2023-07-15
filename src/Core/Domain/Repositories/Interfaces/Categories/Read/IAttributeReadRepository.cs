namespace Domain.Repositories.Interfaces.Categories;

public interface IAttributeReadRepository : IRepository
{
    Task<Aggregates.CategoryAggregate.Attribute> GetAsync(long Id);
    Task<List<Aggregates.CategoryAggregate.Attribute>> GetAllAsync();
    Task<Aggregates.CategoryAggregate.Attribute> GetAsyncNoTracking(long Id);

}
