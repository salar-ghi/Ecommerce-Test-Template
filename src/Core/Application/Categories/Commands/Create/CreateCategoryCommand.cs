namespace Application.Categories.Commands.Create;

//public sealed record CreateCategoryCommand : CategoryReqDto, IRequest<CategoryResDto> 
public sealed record CreateCategoryCommand : IRequest<CategoryResDto>
{
    public ProductReqDto reqDto { get; init; } = default!;
}
