namespace Application.Categories.Queries.GetCategory;

public sealed class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
{
    public GetCategoryQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("category Id cann't be null");
    }
}
