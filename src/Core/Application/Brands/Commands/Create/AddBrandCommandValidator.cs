namespace Application.Brands.Commands.Create;

public sealed class AddBrandCommandValidator : AbstractValidator<AddBrandCommand>
{
    public AddBrandCommandValidator()
    {
        RuleFor(b => b)
            .NotEmpty().WithMessage("")
            .NotNull().WithMessage("")
            ;


    }
}
