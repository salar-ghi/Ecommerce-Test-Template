namespace Domain.Aggregates.ProductAggregate;

public class ProductImage : Entity
{

    public ProductImage(long id, string imageUrl, bool isMain, Guid productId)
    {
        SetImageUrl(imageUrl);
        SetIsMain(isMain);
        Id = Guard.Against.Null(id, nameof(id));
        ProductId = Guard.Against.Null(productId, nameof(productId));
    }

    private ProductImage() { }
    public string ImageUrl { get; private set; } = default!;
    public bool IsMain { get; private set; }
    public Guid ProductId { get; private set; } = default!;
    public void SetIsMain(bool isMain) => IsMain = isMain;
    public void SetImageUrl(string url) => ImageUrl = url;

}
