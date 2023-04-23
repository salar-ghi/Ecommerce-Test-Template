namespace Application.Products.Queries.GetProduct;

public sealed record GetProductQuery(ProductId Id) : IRequest<ProductResDto>;