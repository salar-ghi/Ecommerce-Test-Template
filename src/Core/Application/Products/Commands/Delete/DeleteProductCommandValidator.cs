namespace Application.Products.Commands.Delete;

public sealed class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id.Value)
            .NotNull().WithMessage("Product Id is required");

    }
}
