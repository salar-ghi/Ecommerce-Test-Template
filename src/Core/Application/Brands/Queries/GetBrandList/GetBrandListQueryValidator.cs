namespace Application.Brands.Queries.GetBrandList;

internal class GetBrandListQueryValidator : AbstractValidator<GetBrandListQuery>
{
    public GetBrandListQueryValidator()
    {
        RuleFor(x => x.PageIndex)
                .GreaterThanOrEqualTo(1).WithMessage("PageIndex at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
