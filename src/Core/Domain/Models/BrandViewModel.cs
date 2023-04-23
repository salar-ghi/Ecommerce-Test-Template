namespace Domain.Models;

public record BrandViewModel
{

}

public record BrandFilterPageVM : BaseFilterPageVM<BrandId>
{
    public string Name { get; set; }
}
