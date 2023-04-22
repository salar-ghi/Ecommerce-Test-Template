namespace Domain.Entities.Brands;

public class Brand 
    : Entity<BrandId> , IAggregateRoot
{
    public Brand() { }

    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string? PicUrl { get; private set; }
    


    public static Brand Create(BrandId id, string name, string description, 
        string picUrl, bool isRemoved, bool isActive)
    {
        var brand = new Brand { Id = Guard.Against.Null(id)};
        brand.Created = DateTime.UtcNow;
        brand.Name = name;
        brand.Description = description;
        brand.PicUrl = picUrl;
        brand.CheckIsRemoved(isActive);
        brand.CheckIsActive(isActive);

        return brand;
    }



    public bool CheckIsRemoved(bool? state)
    {
        return IsRemoved = state ?? false;
    }

    public bool CheckIsActive(bool? state)
    {
        return IsActive = state ?? true;
    }

}
