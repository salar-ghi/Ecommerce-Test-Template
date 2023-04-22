namespace Domain.ValueObjects.Categories;

public record CategoryId
{
    public long Value { get; private set; } = default!;
    private CategoryId(long value) { Value = value; }

    public static implicit operator long(CategoryId id) => id.Value;

    public static CategoryId Of(long id) => new(Guard.Against.NegativeOrZero(id));

}
