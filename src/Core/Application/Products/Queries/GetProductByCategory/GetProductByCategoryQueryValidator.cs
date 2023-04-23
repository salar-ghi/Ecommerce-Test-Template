namespace Application.Products.Queries.GetProductByCategory;

public sealed class GetProductByCategoryQueryValidator : AbstractValidator<GetProductByCategoryQuery>
{
    public GetProductByCategoryQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Category Id cannot be null");

        //RuleFor(x => x.PageIndex)
        //    .GreaterThanOrEqualTo(1).WithMessage("PageIndex at least greater than or equal to 1.");

        //RuleFor(x => x.PageSize)
        //    .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
