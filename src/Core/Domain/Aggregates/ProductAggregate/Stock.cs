namespace Domain.Aggregates.ProductAggregate;

public class Stock : ValueObject
{
    private Stock() { }

    public int Available { get; private set; } = default!;
    // Gets available stock at which we should reorder.
    public int RestockThreshold { get; private set; } = default!;

    // Gets maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses).
    public int MaxStockThreshold { get; private set; } = default!;
    public Guid ProductId { get; protected set; } = default!;
    public static Stock Of(int available, int restockThreshold, int maxStockThreshold)
    {
        var stock = new Stock
        {
            Available = Guard.Against.Negative(available),
            RestockThreshold = Guard.Against.NegativeOrZero(restockThreshold),
            MaxStockThreshold = Guard.Against.NegativeOrZero(maxStockThreshold),
        };

        if (stock.Available > stock.MaxStockThreshold)
            throw new EntityDomainException("Available stock cannot be greater than max stock threshold.");

        return stock;
    }



    //public int DebitStock(int quantity)
    //{
    //    if (quantity < 0)
    //        quantity *= -1;

    //    if (HasStock(quantity) == false)
    //    {
    //        throw new EntityDomainException(
    //            $"Empty stock, product item '{Name}' with quantity '{quantity}' is not available."
    //        );
    //    }
    //    int removed = Math.Min(quantity, Stock.Available);
    //    Stock = Stock.Of(Stock.Available - removed, Stock.RestockThreshold, Stock.MaxStockThreshold);
    //    return removed;
    //}
    //public Stock ReplenishStock(int quantity)
    //{
    //    if (Stock.Available + quantity > Stock.MaxStockThreshold)
    //    {
    //        throw new EntityDomainException(
    //            $"Max stock threshold has been reached. Max stock threshold is {Stock.MaxStockThreshold}"
    //        );
    //    }
    //    Stock = Stock.Of(Stock.Available + quantity, Stock.RestockThreshold, Stock.MaxStockThreshold);
    //    return Stock;
    //}

    //public Stock ChangeMaxStockThreshold(int maxStockThreshold)
    //{
    //    Guard.Against.NegativeOrZero(maxStockThreshold, nameof(maxStockThreshold));
    //    Stock = Stock.Of(Stock.Available, Stock.RestockThreshold, maxStockThreshold);
    //    return Stock;
    //}

    //public Stock ChangeRestockThreshold(int restockThreshold)
    //{
    //    Guard.Against.NegativeOrZero(restockThreshold, nameof(restockThreshold));
    //    Stock = Stock.Of(Stock.Available, restockThreshold, Stock.MaxStockThreshold);
    //    return Stock;
    //}
    //public bool HasStock(int quantity)
    //{
    //    return Stock.Available >= quantity;
    //}
}
