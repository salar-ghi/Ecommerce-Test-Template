using Infrastructure.UoW;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<DataContext>(options => options.);

        services.AddScoped<IReadUnitOfWork, ReadUnitOfWork>();
        services.AddScoped<IWriteUnitOfWork, WriteUnitOfWork>();

        services.AddScoped<IBrandReadRepository, BrandReadRepository>();
        services.AddScoped<IBrandWriteRepository<Brand>, BrandWriteRepository>();

        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository<Category>, CategoryWriteRepository>();

        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository<Product>, ProductWriteRepository>();

        return services;
    }
}
