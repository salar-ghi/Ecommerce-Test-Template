namespace Application.Products.Commands.Delete;

public sealed record DeleteProductCommand(ProductId Id) : IRequest;
