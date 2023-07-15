namespace Application.Brands.Commands.Update;

public sealed class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(b => b.Id)
            .NotNull().WithMessage("brand Id cann't be null")
            .NotEqual(0).WithMessage("brand Name cann't be empty or whitespace")
            ;

        RuleFor(b => b.Name)
            .NotNull().WithMessage("brand Name cann't be null")
            .NotEmpty().WithMessage("brand Name cann't be empty or whitespace")
            .MaximumLength(30).WithMessage("brand name cann't be more than 30 characters");

        RuleFor(b => b.Description)
            .MaximumLength(500).WithMessage("brand Description must not be more than 500 characters");
    }

}
