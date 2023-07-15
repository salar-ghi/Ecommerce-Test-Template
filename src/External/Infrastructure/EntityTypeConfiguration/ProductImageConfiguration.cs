namespace Infrastructure.EntityTypeConfiguration;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.IsMain).IsRequired();
        builder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(500)
            .HasDefaultValue("https://via.placeholder.com/200x340.png");
    }
}
