namespace Application.Categories.Commands.Delete;

public sealed record DeleteCategoryCommand(CategoryId Id) : IRequest;
