namespace Domain.ValueObjects.Products;

public record Size
{
    private Size(string value) { Value = value; }
    public string Value { get; private set; }
    public static Size Of(string value)
    {
        Guard.Against.NullOrWhiteSpace(value);
        return new Size(value);
    }


    public static implicit operator string(Size value) => value.Value;

}
