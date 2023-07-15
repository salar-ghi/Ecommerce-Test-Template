namespace Application.Categories.Queries.GetCategory;

public sealed record GetCategoryQuery(long Id ): IRequest<CategoryResDto>;
