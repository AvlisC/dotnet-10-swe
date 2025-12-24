using ProductApi.Application.UseCases.Products;
using Microsoft.Extensions.DependencyInjection;

namespace ProductApi.Application.DependencyInjection;

public static class ApplicationInjectionServices
{
    public static IServiceCollection AddApplicationServicesInjection(
        this IServiceCollection services)
    {
        services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
        services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
        services.AddScoped<IListProductUseCase, ListProductUseCase>();
        services.AddScoped<IGetByIdProductUseCase, GetByIdProductUseCase>();
        services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();

        return services;
    }
}
