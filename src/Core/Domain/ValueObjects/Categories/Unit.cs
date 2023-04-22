namespace Domain.ValueObjects.Categories;

public class Unit : ValueObject
{
    private Unit() { }
    public CategoryId CategoryId { get; private set; }
    public string Value { get; private set; } = default!;


    public static Unit Create(long id, CategoryId categoryId, string value)
    {
        var unit = new Unit { Id = Guard.Against.Null(id, nameof(id)) };
        unit.CheckValue(value);
        unit.CheckCategoryId(categoryId);
        unit.Created = DateTime.UtcNow;

        return unit;
    }

    public void CheckValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new EntityDomainException("Key cannot be null");
        //Guard.Against.NullOrWhiteSpace(Key,);

        Value = value;
    }

    public void CheckCategoryId(CategoryId categoryId)
    {
        Guard.Against.Null(categoryId, new EntityDomainException("Category Id cannot be null").ToString());
        Guard.Against.NegativeOrZero(categoryId);

        CategoryId = categoryId;
    }
}
