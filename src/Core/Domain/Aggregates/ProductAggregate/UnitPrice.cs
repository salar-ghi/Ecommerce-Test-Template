namespace Domain.Aggregates.ProductAggregate;

public class UnitPrice : ValueObject
{
    // category unit Id
    public long UnitId { get; private set; } = default(long);
    public Guid ProductId { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;
    public void CheckProductId(Guid productId)
    {
        Guard.Against.Null(productId, new EntityDomainException("product Id cannot be null").ToString());
        ProductId = productId;
    }
    public void CheckUnitId(long unitId)
    {
        Guard.Against.Null(unitId, new EntityDomainException("unit Id cannot be null").ToString());
        Guard.Against.NegativeOrZero(unitId);

        UnitId = unitId;
    }
    public void ChcekPrice(decimal price)
    {
        Guard.Against.Null(price, nameof(price), new EntityDomainException("Price cannot be null.").ToString());

        if (Price == price)
            return;

        Price = price;
    }
    public static UnitPrice Create(long id, long unitId, Guid productId, decimal price)
    {
        var unitPrice = new UnitPrice { Id = Guard.Against.Null(id, nameof(id)) };
        unitPrice.ChcekPrice(price);
        unitPrice.CheckProductId(productId);
        unitPrice.CheckUnitId(unitId);

        return unitPrice;
    }

    public static implicit operator decimal(UnitPrice value) => value.Price;
}
