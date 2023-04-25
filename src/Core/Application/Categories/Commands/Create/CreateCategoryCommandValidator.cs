namespace Application.Categories.Commands.Create;

public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category Name cann't be null");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("category Description length cann't be more 500 characters");
    }
}
