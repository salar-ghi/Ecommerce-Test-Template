namespace Domain.ValueObjects.Categories;

public class Attribute : ValueObject
{
    public string Key { get; private set; } = default!;

    public CategoryId CategoryId { get; private set; } = default!;
    //public Category Categories { get; private set; }

    public static Attribute Create(long id, CategoryId categoryId, string key)
    {
        var attribute = new Attribute { Id = Guard.Against.Null(id, nameof(id)) };
        attribute.CheckKey(key);
        attribute.CheckCategoryId(categoryId);
        attribute.Created = DateTime.UtcNow;

        return attribute;
    }

    public void CheckKey(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new EntityDomainException("Key cannot be null");
        //Guard.Against.NullOrWhiteSpace(Key,);

        Key = key;
    }

    public void CheckCategoryId(CategoryId categoryId)
    {
        Guard.Against.Null(categoryId, new EntityDomainException("Category Id cannot be null").ToString());
        Guard.Against.NegativeOrZero(categoryId);

        CategoryId = categoryId;
    }

}
