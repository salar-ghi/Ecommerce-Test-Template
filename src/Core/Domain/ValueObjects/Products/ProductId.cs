namespace Domain.ValueObjects.Products;

public record ProductId
{
    public Guid Value { get; private set; } = default!;
    private ProductId(Guid value) { Value = value; }

    // validations should be placed here instead of constructor
    public static ProductId Of(Guid id) => new(Guard.Against.Null(id));

    public static implicit operator Guid(ProductId id) => id.Value;
}
