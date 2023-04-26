namespace Infrastructure.EntityTypeConfiguration;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

        builder.Property(p => p.PicUrl).HasMaxLength(500)
            .HasDefaultValue("https://via.placeholder.com/85.png");
        builder.Property(p => p.Created).IsRequired().HasDefaultValue(DateTime.UtcNow);
        builder.Property(p => p.Modified).IsRequired().HasDefaultValue(DateTime.UtcNow);
    }
}
