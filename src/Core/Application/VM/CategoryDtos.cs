using Domain.ValueObjects.Categories;

namespace Application.VM;

public record CategoryDtos
{
    public string Name { get; private set; } = default!;
    public int ParentId { get; private set; } = default!;
    public string CoverPicUrl { get; private set; } = default!;
    public string? Description { get; private set; }
    public string Code { get; private set; } = default!;
    public ActivationStatus IsActive { get; private set; }
    public string Permalink { get; private set; } = default!;
    public int Priority { get; private set; } = default!;
    public string BannerUrl { get; private set; } = default!;
    public string ThumbnailUrl { get; private set; } = default!;
}


public record CategoryResDto : CategoryDtos
{
    public long Id { get; init; }
}


public record CategoryReqDto : CategoryDtos
{
    public CategoryId Id { get; init; } = default!;
}




