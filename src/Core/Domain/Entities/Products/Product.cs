namespace Domain.Entities.Products;

public class Product 
    : Entity<ProductId> , IAggregateRoot
{

    private List<ProductImage> _images = new();
    private Product() { }


    public Name Name { get; private set; } = default!;
    
    // ???? Comment it ????
    public Price Price { get; private set; } = default!;
    public ProductStatus ProductStatus { get; private set; }
    public string Code { get; private set; } = default!;
    public string? Description { get; private set; } = default!;
    public Size Size { get; private set; } = default!;
    public Stock Stock { get; private set; } = default!;
    public Dimensions Dimensions { get; private set; } = default!;
    public IReadOnlyList<ProductImage> Images => _images;

    public BrandId BrandId { get; private set; } = default!;
    //public Brand Brand { get; private set; }

    public CategoryId CategoryId { get; private set; } = default!;
    //public Category Category { get; private set; }

    //public int AvailableStock { get; set; }

    //public bool IsRemoved { get; private set; } = default!;
    //public bool IsActive { get; private set; } = default!;



    public static Product Create(
        ProductId id,
        Name name,
        Stock stock,
        ProductStatus status,
        Dimensions dimensions,
        Size size,
        //ProductColor color,
        string? description,
        Price price,
        CategoryId categoryId,
        BrandId brandId,
        bool isRemoved,
        bool isActive,
        IList<ProductImage>? images = null)
    {
        Guard.Against.Null(id, new EntityDomainException("Product id can not be null").ToString());
        Guard.Against.Null(stock.Available, new EntityDomainException("Product stock can not be null").ToString());

        var product = new Product { Id = id, Stock = stock };

        product.ChangeName(name);
        product.CheckSize(size);
        product.ChangeDescription(description);
        product.ChangePrice(price);
        product.AddProductImages(images);
        product.ChangeStatus(status);
        //product.ChangeColor(color);
        product.CheckDimensions(dimensions);
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

    public void CheckDimensions(Dimensions dimensions)
    {
        Guard.Against.Null(dimensions, new EntityDomainException("Dimensions cannot be null.").ToString());

        Dimensions = dimensions;
    }

    public void CheckSize(Size size)
    {
        Guard.Against.Null(size, new EntityDomainException("Size cannot be null.").ToString());

        Size = size;
    }

    public void ChangeName(Name name)
    {
        Guard.Against.Null(name, new EntityDomainException("Product name cannot be null.").ToString());

        Name = name;
    }

    //public void ChangeColor(ProductColor color)
    //{
    //    Color = color;
    //}

    public void ChangeDescription(string? description)
    {
        Description = description;
    }

    public void ChangePrice(Price price)
    {
        Guard.Against.Null(price, new EntityDomainException("Price cannot be null.").ToString());

        if (Price == price)
            return;

        Price = price;

        //AddDomainEvents(new ProductPriceChanged(price));
    }

    ////
    public int DebitStock(int quantity)
    {
        if (quantity < 0)
            quantity *= -1;

        if (HasStock(quantity) == false)
        {
            throw new EntityDomainException(
                $"Empty stock, product item '{Name}' with quantity '{quantity}' is not available."
            );
        }

        int removed = Math.Min(quantity, Stock.Available);

        Stock = Stock.Of(Stock.Available - removed, Stock.RestockThreshold, Stock.MaxStockThreshold);

        //if (Stock.Available <= Stock.RestockThreshold)
        //{
        //    AddDomainEvents(new ProductRestockThresholdReachedEvent(Id, Stock, quantity));
        //}

        //AddDomainEvents(new ProductStockDebited(Id, Stock, quantity));

        return removed;
    }
    public Stock ReplenishStock(int quantity)
    {
        // we don't have enough space in the inventory
        if (Stock.Available + quantity > Stock.MaxStockThreshold)
        {
            throw new EntityDomainException(
                $"Max stock threshold has been reached. Max stock threshold is {Stock.MaxStockThreshold}"
            );
        }

        Stock = Stock.Of(Stock.Available + quantity, Stock.RestockThreshold, Stock.MaxStockThreshold);

        //AddDomainEvents(new ProductStockReplenished(Id, Stock, quantity));

        return Stock;
    }

    public Stock ChangeMaxStockThreshold(int maxStockThreshold)
    {
        Guard.Against.NegativeOrZero(maxStockThreshold, nameof(maxStockThreshold));

        Stock = Stock.Of(Stock.Available, Stock.RestockThreshold, maxStockThreshold);

        //AddDomainEvents(new MaxThresholdChanged(Id, maxStockThreshold));

        return Stock;
    }

    public Stock ChangeRestockThreshold(int restockThreshold)
    {
        Guard.Against.NegativeOrZero(restockThreshold, nameof(restockThreshold));

        Stock = Stock.Of(Stock.Available, restockThreshold, Stock.MaxStockThreshold);

        //AddDomainEvents(new RestockThresholdChanged(Id, restockThreshold));

        return Stock;
    }
    public bool HasStock(int quantity)
    {
        return Stock.Available >= quantity;
    }

    ////

    public bool CheckIsRemoved(bool? state)
    {
        return IsRemoved = state ?? false;
    }

    public bool CheckIsActive(bool? state)
    {
        return IsActive = state ?? true;
    }

    public void Activate() => ChangeStatus(ProductStatus.Available);

    public void DeActive() => ChangeStatus(ProductStatus.Unavailable);

    public void CheckCategory(CategoryId categoryId)
    {
        Guard.Against.Null(categoryId, new EntityDomainException("CategoryId cannot be null").ToString());
        Guard.Against.NegativeOrZero(categoryId);

        CategoryId = categoryId;

        // add event to domain events list that will be raise during commiting transaction
        //AddDomainEvents(new ProductCategoryChanged(categoryId, Id));
    }

    public void CheckBrand(BrandId brandId)
    {
        Guard.Against.Null(brandId, new EntityDomainException("brandId cannot be null").ToString());
        Guard.Against.NegativeOrZero(brandId);

        BrandId = brandId;

        //AddDomainEvents(new ProductBrandChanged(brandId, Id));
    }

    public void AddProductImages(IList<ProductImage>? productImages)
    {
        if (productImages is null)
        {
            _images = null!;
            return;
        }

        _images.AddRange(productImages);
    }
}