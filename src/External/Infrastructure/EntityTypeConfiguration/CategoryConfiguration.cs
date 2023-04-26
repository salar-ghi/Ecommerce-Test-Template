namespace Infrastructure.EntityTypeConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Description).IsRequired().HasMaxLength(5000);
        builder.Property(p => p.Permalink).IsRequired().HasMaxLength(200);
        builder.Property(p => p.BannerUrl).IsRequired().HasMaxLength(50).HasDefaultValue("https://via.placeholder.com/500x100.png");
        builder.Property(p => p.CoverPicUrl).IsRequired().HasMaxLength(50).HasDefaultValue("https://via.placeholder.com/85.png");
        builder.Property(p => p.ThumbnailUrl).IsRequired().HasMaxLength(50).HasDefaultValue("https://via.placeholder.com/150x100.png");
        builder.Property(p => p.Created).IsRequired().HasDefaultValue(DateTime.UtcNow);
        builder.Property(p => p.Modified).IsRequired().HasDefaultValue(DateTime.UtcNow);
    }
}
