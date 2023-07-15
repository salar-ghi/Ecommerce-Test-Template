namespace Application.Products.Commands.Update;

public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{Name} is Required")
            .NotNull()
            .MaximumLength(200).WithMessage("{Name} must not exceed 200 characters");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{Description} is Required")
            .NotNull().MaximumLength(5000).WithMessage("{Description} must not exceed 5000 characters");


        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("{categoryId} is Required")
            .NotEqual(0).WithMessage("{category} must not be zero");

        //RuleFor(p => p.Price.Value)
        //    .NotNull().WithMessage("{Price} is Required")
        //    .GreaterThanOrEqualTo(0).WithMessage("{Price} must not be less than zero");

        //RuleFor(p => p.Stock.Available)
        //    .NotNull().WithMessage("{stock available} is Required")
        //    .GreaterThanOrEqualTo(0).WithMessage("{stock available} must not be less than zero");

        RuleFor(p => p.BrandId)
            .NotEmpty().WithMessage("{Brand Id } is Required")
            .NotEqual(0).WithMessage("{Brand } must not be zero")
            .NotNull().WithMessage("{Brand Id} must not be null }");
    }
}
