namespace Infrastructure.EntityTypeConfiguration;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(5000);
        builder.Property(p => p.BrandId).IsRequired();
        builder.Property(p => p.CategoryId).IsRequired();
        builder.Property(p => p.Code).IsRequired().HasMaxLength(50)
            .HasDefaultValue("https://via.placeholder.com/85.png");
        builder.Property(p => p.Created).IsRequired().HasDefaultValue(DateTime.UtcNow);
        builder.Property(p => p.Modified).IsRequired().HasDefaultValue(DateTime.UtcNow);
    }
}