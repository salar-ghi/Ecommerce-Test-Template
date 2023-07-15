namespace Domain.Aggregates.CategoryAggregate;

public class Unit : ValueObject
{
    private Unit() { }
    public long CategoryId { get; private set; }
    public int Value { get; private set; } = default!;
    public UnitType unitType { get; set; }


    public static Unit Create(long id, long categoryId, int value)
    {
        var unit = new Unit { Id = Guard.Against.NegativeOrZero(id, nameof(id)) };
        unit.CheckValue(value);
        unit.CheckCategoryId(categoryId);
        unit.Created = DateTime.UtcNow;

        return unit;
    }

    public void CheckValue(int value)
    {
        //if (Guard.Against.NegativeOrZero(value))
        //    throw new EntityDomainException("Key cannot be null");

        Value = value;
    }

    public void CheckCategoryId(long categoryId)
    {
        Guard.Against.Null(categoryId, new EntityDomainException("Category Id cannot be null").ToString());
        Guard.Against.NegativeOrZero(categoryId);

        CategoryId = categoryId;
    }
}