namespace Infrastructure.Mapping;

public class BrandMappingProfile : Profile
{
    public BrandMappingProfile()
    {
        CreateMap<Brand, BrandReqDto>().ReverseMap();
        CreateMap<Brand, BrandResDto>().ReverseMap();
    }
}
