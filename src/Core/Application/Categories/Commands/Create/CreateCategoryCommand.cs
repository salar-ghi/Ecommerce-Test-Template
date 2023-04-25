namespace Application.Categories.Commands.Create;

public sealed record CreateCategoryCommand : CategoryReqDto, IRequest<CategoryResDto>;
