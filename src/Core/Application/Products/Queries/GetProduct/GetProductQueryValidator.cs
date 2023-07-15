namespace Application.Products.Queries.GetProduct;

public sealed class GetProductQueryValidator : AbstractValidator<GetProductQuery>
{
    public GetProductQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Product Id is required");
    }
}
