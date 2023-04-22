namespace Domain.ValueObjects.Products;

public record Price
{
    private Price(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; private set; }

    public static Price Of(decimal value)
    {
        Guard.Against.NegativeOrZero(value);

        return new Price(value);
    }

    public static implicit operator decimal(Price value) => value.Value;

}
