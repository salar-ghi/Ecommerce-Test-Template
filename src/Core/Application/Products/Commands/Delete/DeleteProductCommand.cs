namespace Application.Products.Commands.Delete;

public sealed record DeleteProductCommand(Guid Id) : IRequest;
