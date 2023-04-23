namespace Application.VM;

public record BrandDtos
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public string? PicUrl { get; init; }
}



public record BrandReqDto : BrandDtos { }

public record BrandUpdateReqDto : BrandDtos 
{
    public BrandId Id { get; init; }
}



public record BrandResDto : BrandDtos
{
    public BrandId Id { get; private set; } = default!;
}


