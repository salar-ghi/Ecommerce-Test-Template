namespace Application.Brands.Commands.Delete;

public sealed record DeleteBrandCommand(BrandId Id) : IRequest;
