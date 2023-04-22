namespace Application.Products.Commands.Create;

public sealed record CreateProductCommand : ProductReqDto, IRequest<ProductResDto>;
