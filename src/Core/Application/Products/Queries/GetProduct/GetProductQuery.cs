namespace Application.Products.Queries.GetProduct;

public sealed record GetProductQuery(ProductId Id) : IRequest<ProductResDto>;

//public sealed record GetProductQuery(Guid Id) : IRequest<Result<ProductResDto>>;