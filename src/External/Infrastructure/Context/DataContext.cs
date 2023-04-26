namespace Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }


    
    public DbSet<Brand> Brands { get; set; }
    
    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }
    public DbContext AppDbContext => this;

    public async Task MigrateAsync() => await AppDbContext.Database.MigrateAsync();


    //private void UpdateEntities()
    //{
    //    foreach (var entry in ChangeTracker.Entries<string>())
    //    {
    //        if (entry.Entity.)
    //            entry.State = EntityState.Added;
    //    }
    //}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.ApplyConfiguration(new BrandConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }



}
