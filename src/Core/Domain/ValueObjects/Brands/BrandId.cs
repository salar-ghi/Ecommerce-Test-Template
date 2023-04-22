namespace Domain.ValueObjects.Brands;

public record BrandId
{
    public int Value { get; private set; } = default!;
    private BrandId(int value) { Value = value; }

    public static implicit operator int(BrandId id) => id.Value;

    public static BrandId Of(int id) => new(Guard.Against.NegativeOrZero(id));
}
