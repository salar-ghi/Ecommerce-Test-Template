namespace Application.Categories.Queries.GetCategoryList;

public sealed record GetCategoryListQuery
    : CategoryFilterPageVM, IRequest<PaginitionResDto<List<CategoryResDto>>>;
