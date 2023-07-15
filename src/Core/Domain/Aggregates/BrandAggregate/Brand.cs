using ErrorOr;

namespace Domain.Aggregates.BrandAggregate;

public class Brand : AggregateRoot<int>
{
    public Brand() { }

    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string? PicUrl { get; private set; }


    public static Brand Create(int id, string name, string description,
        string picUrl, bool isRemoved, ActivationStatus isActive, Guid createdBy, Guid modifiedBy)
    {
        var brand = new Brand { Id = Guard.Against.NegativeOrZero(id, nameof(id)) };
        brand.Name = name;
        brand.Description = description;
        brand.PicUrl = picUrl;
        brand.CheckIsRemoved(isRemoved);
        brand.CheckIsActive(isActive);
        brand.Created = DateTime.UtcNow;
        brand.CreatedBy = createdBy;
        brand.ModifiedBy = modifiedBy;

        return brand;
    }

    public static Brand Update(int id, string name, string description,
        string picUrl, bool isRemoved, ActivationStatus isActive, Guid modifiedBy)
    {
        var brand = new Brand { Id = Guard.Against.NegativeOrZero(id, nameof(id)) };
        brand.Name = name;
        brand.Description = description;
        brand.PicUrl = picUrl;
        brand.CheckIsRemoved(isRemoved);
        brand.CheckIsActive(isActive);
        brand.Modified = DateTime.UtcNow;
        brand.ModifiedBy = modifiedBy;

        return brand;
    }




    public bool CheckIsRemoved(bool? state)
    {
        return IsRemoved = state ?? false;
    }

    public bool CheckIsActive(ActivationStatus state)
    {
        return IsActive == state;
    }
}
