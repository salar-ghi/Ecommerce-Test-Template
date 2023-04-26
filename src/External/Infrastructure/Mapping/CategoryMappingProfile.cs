namespace Infrastructure.Mapping;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryReqDto>().ReverseMap();
        CreateMap<Category, CategoryResDto>().ReverseMap();

    }
}
