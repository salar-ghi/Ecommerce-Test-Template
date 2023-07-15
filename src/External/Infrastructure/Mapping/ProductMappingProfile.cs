namespace Infrastructure.Mapping;
public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductReqDto>().ReverseMap();
        CreateMap<Product, ProductResDto>()
            //.ForMember(dest => dest.CategoryName,
            //config => config.MapFrom(src => $"{src.category.Title}({src.CategoryId})"))
            .ReverseMap();
    }
}
