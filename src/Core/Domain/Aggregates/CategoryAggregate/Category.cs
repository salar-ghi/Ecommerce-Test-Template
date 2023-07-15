namespace Domain.Aggregates.CategoryAggregate;

public class Category : AggregateRoot<long>
{
    public Category() { }

    public string Name { get; private set; } = default!;
    public long ParentId { get; private set; } = default!;
    public string CoverPicUrl { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string Code { get; private set; } = default!;
    public string Permalink { get; private set; } = default!;
    public int Priority { get; private set; } = default!;
    public string BannerUrl { get; private set; } = default!;
    public string ThumbnailUrl { get; private set; } = default!;


    public static Category Create(long id, string name, string coverPicUrl,
        string code, ActivationStatus isActive, string permalink, int priority, string bannerUrl,
        string thumbnailUrl, bool isRemoved, int parentId, string description)
    {
        var category = new Category { Id = id };
        category.CheckName(name);
        category.CheckCode(code);
        category.CheckActivationStatus(isActive);
        category.CheckIsRemoved(isRemoved);
        category.CoverPicUrl = coverPicUrl;
        category.Permalink = permalink;
        category.Priority = priority;
        category.BannerUrl = bannerUrl;
        category.ThumbnailUrl = thumbnailUrl;
        category.ParentId = parentId;
        category.Description = description ?? "";

        return category;
    }


    public void CheckName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new EntityDomainException("Name cann't be white space or null.");

        Name = name;
    }

    public void CheckCode(string code)
    {
        if (string.IsNullOrWhiteSpace(Code))
            throw new EntityDomainException("Code cann't be white space or null.");

        Code = code;
    }

    public void CheckActivationStatus(ActivationStatus active)
    {
        //Guard.Against.NullOrEmpty(isActive, new CategoryDomainException("category active status can't be null"));

        IsActive = active;
    }

    public bool CheckIsRemoved(bool? state)
    {
        return IsRemoved = state ?? false;
    }

    //public void CheckParentId(int parentId)
    //{
    //    if (parentId is null)
    //        throw new CategoryDomainException("Parent Id cann't be null"));

    //    ParentId = parentId;
    //}



}
