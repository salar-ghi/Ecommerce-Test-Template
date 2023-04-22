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
    public int Id { get; }
    //public string Name { get; } = default!;
    //public string? Description { get;}
    //public string? PicUrl { get; }
}


