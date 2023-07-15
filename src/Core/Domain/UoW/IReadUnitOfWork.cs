namespace Domain.UoW;

public interface IReadUnitOfWork : IUnitOfWork , IDisposable
{
    ICategoryReadRepository CategoryReadRepository { get; }
    IBrandReadRepository BrandReadRepository { get; }
    IProductReadRepository ProductReadRepository { get; }

    //int complete()
}
