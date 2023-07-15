namespace Domain.Aggregates.ProductAggregate;

public class ProductAttribute : ValueObject
{
    public ProductAttribute() { }

    public Guid ProductId { get; private set; } = default!;
    public long AttributeId { get; private set; } = default!;

    public string Value { get; private set; } = default!;
    public static ProductAttribute Create(long id, long attributeId, string value)
    {
        var attributeValue = new ProductAttribute { Id = Guard.Against.Null(id, nameof(id)) };
        attributeValue.CheckAttributeId(attributeId);
        attributeValue.CheckValue(value);
        attributeValue.Created = DateTime.UtcNow;

        return attributeValue;
    }
    public void CheckValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new EntityDomainException("value cannot be null");

        Value = value;
    }
    public void CheckAttributeId(long attributeId)
    {
        Guard.Against.Null(attributeId, new EntityDomainException("attribute Id cannot be null").ToString());
        Guard.Against.NegativeOrZero(attributeId, nameof(attributeId), new EntityDomainException("attribute Id cannot be null").ToString());

        AttributeId = attributeId;
    }

}
