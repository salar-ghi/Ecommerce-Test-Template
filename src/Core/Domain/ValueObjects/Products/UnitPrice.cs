namespace Domain.ValueObjects.Products;

public class UnitPrice : ValueObject
{
    //private UnitPrice(decimal price)
    //{
    //    Price = price;
    //}
    public long UnitId { get; private set; }
    public ProductId ProductId { get; private set; } = default!;
    public decimal Price { get; private set; }



    public void CheckProductId(ProductId productId)
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
        Guard.Against.Null(price, nameof(price) ,new EntityDomainException("Price cannot be null.").ToString());

        if (Price == price)
            return;

        Price = price;
    }

    public static UnitPrice Create(long id, long unitId, ProductId productId, decimal price)
    {
        var unitPrice = new UnitPrice { Id = Guard.Against.Null(id, nameof(id)) };
        unitPrice.ChcekPrice(price);
        unitPrice.CheckProductId(productId);
        unitPrice.CheckUnitId(unitId);

        return unitPrice;
    }

    //public static UnitPrice Of(decimal value)
    //{
    //    Guard.Against.NegativeOrZero(value);

    //    return new UnitPrice(value);
    //}

    public static implicit operator decimal(UnitPrice value) => value.Price;
}
