namespace Application.Products.Queries.GetProductByBrand;

public sealed class GetProductByBrandQueryValidator : AbstractValidator<GetProductByBrandQuery>
{
    public GetProductByBrandQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Brand Id is required");

        //RuleFor(x => x.PageIndex)
        //    .GreaterThanOrEqualTo(1).WithMessage("PageIndex at least greater than or equal to 1.");

        //RuleFor(x => x.PageSize)
        //    .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
