namespace Application.Products.Queries.GetProduct;

public sealed record GetProductQuery(Guid Id) : IRequest<ProductResDto>;