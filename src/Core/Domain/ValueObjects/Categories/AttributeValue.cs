namespace Domain.ValueObjects.Categories;

public class AttributeValue : ValueObject
{

    private AttributeValue() { }

    public string Value { get; private set; } = default!;
    public long AttributeId { get; private set; } = default!;
    //public Attribute Attribute { get; private set; } = default!;

    public static AttributeValue Create(long id, long attributeId, string value)
    {
        var attributeValue = new AttributeValue { Id = Guard.Against.Null(id, nameof(id)) };
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
