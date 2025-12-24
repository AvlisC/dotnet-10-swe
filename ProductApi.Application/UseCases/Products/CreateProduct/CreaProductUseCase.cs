using ProductApi.Application.Abstractions.Repositories;
using ProductApi.Application.DTOs;
using ProductApi.Domain;

namespace ProductApi.Application.UseCases.Products;

public class CreateProductUseCase(IProductRepository repository) : ICreateProductUseCase
{
    private readonly IProductRepository _repository = repository;

    public async Task<ProductResponse> ExecuteAsync(string name, string description, decimal price)
    {
        ProductEntity product = new ProductEntity(name, description, price);

        await _repository.AddAsync(product);

        return new ProductResponse(product.Id, product.Name, product.Description, product.Price);
    }
}
