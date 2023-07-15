namespace Domain.Aggregates.ProductAggregate;

public class Product : AggregateRoot<Guid>
{
    private Product() { }

    public string Name { get; private set; } = default!;
    public ProductStatus ProductStatus { get; private set; }
    public string Code { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public int BrandId { get; private set; } = default!;
    public long CategoryId { get; private set; } = default!;
    //public int supplierId { get; private set; } = default!;


    //ProductColor color, ???????????????????????????????????????????????


    public static Product Create(Guid id, string name,
        ProductStatus status, string? description, 
        int brandId, long categoryId, bool isRemoved, ActivationStatus isActive)
    {
        Guard.Against.Null(id, new EntityDomainException("Product id can not be null").ToString());
        //Guard.Against.Null(stock.Available, new EntityDomainException("Product stock can not be null").ToString());

        var product = new Product { Id = id };
        product.ChangeName(name);
        product.ChangeDescription(description);
        product.ChangeStatus(status);
        product.CheckCategory(categoryId);
        product.CheckBrand(brandId);
        product.CheckIsRemoved(isRemoved);
        product.CheckIsActive(isActive);
        return product;
    }


    public void ChangeStatus(ProductStatus status)
    {
        ProductStatus = status;
    }

    public void ChangeName(string name)
    {
        Guard.Against.Null(name, new EntityDomainException("Product name cannot be null.").ToString());
        Name = name;
    }

    public bool CheckIsRemoved(bool? state)
    {
        return IsRemoved = state ?? false;
    }

    public bool CheckIsActive(ActivationStatus state)
    {
        return IsActive == state;
    }

    public void Activate() => ChangeStatus(ProductStatus.Available);

    public void DeActive() => ChangeStatus(ProductStatus.Unavailable);

    public void CheckCategory(long categoryId)
    {
        Guard.Against.Null(categoryId, new EntityDomainException("CategoryId cannot be null").ToString());
        Guard.Against.NegativeOrZero(categoryId);
        CategoryId = categoryId;
    }

    public void CheckBrand(int brandId)
    {
        Guard.Against.Null(brandId, new EntityDomainException("brandId cannot be null").ToString());
        Guard.Against.NegativeOrZero(brandId);

        BrandId = brandId;

        //AddDomainEvents(new ProductBrandChanged(brandId, Id));
    }

    public void CheckSupplier(int supplierId)
    {
        Guard.Against.Null(supplierId, new EntityDomainException("supplierId cannot be null").ToString());
        Guard.Against.NegativeOrZero(supplierId);

        BrandId = supplierId;
    }

    //public void ChangeColor(ProductColor color)
    //{
    //    Color = color;
    //}

    public void ChangeDescription(string? description)
    {
        Description = description;
    }

    //public void CheckDimensions(Dimensions dimensions)
    //{
    //    Guard.Against.Null(dimensions, new EntityDomainException("Dimensions cannot be null.").ToString());
    //    Dimensions = dimensions;
    //}

    //public void CheckSize(Size size)
    //{
    //    Guard.Against.Null(size, new EntityDomainException("Size cannot be null.").ToString());
    //    Size = size;
    //}


    //public void ChangePrice(Price price)
    //{
    //    Guard.Against.Null(price, new EntityDomainException("Price cannot be null.").ToString());
    //    if (Price == price)
    //        return;
    //    Price = price;
    //}

    ////
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

    ////

    //public void AddProductImages(IList<ProductImage>? productImages)
    //{
    //    if (productImages is null)
    //    {
    //        _images = null!;
    //        return;
    //    }

    //    _images.AddRange(productImages);
    //}
}