namespace Application.Brands.Queries.GetBrand;

public sealed class GetBrandQueryValidator : AbstractValidator<GetBrandQuery>
{
    public GetBrandQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Brand Id cann't be null");
    }
}
