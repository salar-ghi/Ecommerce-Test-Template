namespace Application.Brands.Commands.Create;

//public sealed record AddBrandCommand(BrandReqDto request) : IRequest<BrandResDto>
public sealed record AddBrandCommand : BrandReqDto, IRequest<BrandResDto>
{
}
