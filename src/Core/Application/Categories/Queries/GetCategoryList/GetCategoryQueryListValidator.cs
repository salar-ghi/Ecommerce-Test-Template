namespace Application.Categories.Queries.GetCategoryList;

public sealed class GetCategoryQueryListValidator : AbstractValidator<GetCategoryListQuery>
{
    public GetCategoryQueryListValidator()
    {
        RuleFor(x => x.ParentId)
            .NotEqual(0).WithMessage("parnt Id cann't be zero");

        RuleFor(x => x.PageIndex)
                .GreaterThanOrEqualTo(1).WithMessage("PageIndex at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
