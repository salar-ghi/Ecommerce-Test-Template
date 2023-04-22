namespace Infrastructure.EntityTypeConfiguration;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
