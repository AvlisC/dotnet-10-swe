using ProductApi.Application.Abstractions.Repositories;
using ProductApi.Application.DTOs;
using ProductApi.Domain;

namespace ProductApi.Application.UseCases.Products;

public class GetByIdProductUseCase(IProductRepository repository) : IGetByIdProductUseCase
{
    private readonly IProductRepository _repository = repository;

    public async Task<ProductResponse> ExecuteAsync(Guid id)
    {
        ProductEntity product = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Produto não encontrado");

        ProductResponse productResponseMapped = new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Price
        );

        return productResponseMapped;
    }
}
