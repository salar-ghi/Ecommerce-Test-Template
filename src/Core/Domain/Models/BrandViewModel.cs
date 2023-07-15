namespace Domain.Models;

public record BrandViewModel
{

}

public record BrandFilterPageVM : BaseFilterPageVM<int>
{
    public string Name { get; set; }
}
