namespace Domain.ValueObjects.Products;

public class ProductAttribute : ValueObject
{
    public ProductId ProductId { get; private set; }
    public long AttributeValueId { get; private set; }

}
