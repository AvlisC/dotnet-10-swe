using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductApi.Application.Abstractions.Repositories;
using ProductApi.Infrastructure.Persistence.Context;
using ProductApi.Infrastructure.Persistence.Repositories;

namespace ProductApi.Infrastructure.DependencyInjection;

public static class InfrastructureServicesInjection
{
    public static IServiceCollection AddInfrastructureServicesInjection(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString, optionsBuilder => optionsBuilder.MigrationsAssembly("ProductApi.Infrastructure")));

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
