namespace Application.Brands.Commands.Delete;

public sealed class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
{
    public DeleteBrandCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Brand Id Cann't be null")
            .NotEqual(0).WithMessage("Brand Id cann't be zero");
    }
}
