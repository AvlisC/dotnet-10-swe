using ProductApi.Application.Abstractions.Repositories;
using ProductApi.Application.DTOs;
using ProductApi.Domain;

namespace ProductApi.Application.UseCases.Products;

public class UpdateProductUseCase(IProductRepository repository) : IUpdateProductUseCase
{
    private readonly IProductRepository _repository = repository;

    public async Task<ProductResponse> ExecuteAsync(Guid id, string name, string description, decimal price)
    {
        ProductEntity product = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Produto não encontrado");

        product.ChangeName(name);
        product.ChangeDescription(description);
        product.ChangePrice(price);

        await _repository.UpdateAsync(product);

        ProductResponse productResponseMapped = new ProductResponse(product.Id, product.Name, product.Description, product.Price);

        return productResponseMapped;
    }
}
