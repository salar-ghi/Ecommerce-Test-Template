namespace Application.Categories.Queries.GetCategory;

public sealed record GetCategoryQuery(CategoryId Id ): IRequest<CategoryResDto>;
