namespace Application.Brands.Commands.Create;

public sealed class AddBrandCommandValidator : AbstractValidator<AddBrandCommand>
{
    public AddBrandCommandValidator()
    {
        RuleFor(b => b.Name)
            .NotNull().WithMessage("brand Name cann't be null")
            .NotEmpty().WithMessage("brand Name cann't be empty or whitespace")
            .MaximumLength(30).WithMessage("brand name cann't be more than 30 characters");

        RuleFor(b => b.Description)
            .MaximumLength(500).WithMessage("brand Description must not be more than 500 characters");
    }
}
