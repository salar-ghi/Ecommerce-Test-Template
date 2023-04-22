namespace Domain.ValueObjects.Products;

public record Stock
{
    private Stock() { }


    //public long Id { get; private set; } = default!;
    // Get quantity in Stock
    public int Available { get; private set; } = default!;

    // Gets available stock at which we should reorder.
    public int RestockThreshold { get; private set; } = default!;

    // Gets maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses).
    public int MaxStockThreshold { get; private set; } = default!;


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
}
