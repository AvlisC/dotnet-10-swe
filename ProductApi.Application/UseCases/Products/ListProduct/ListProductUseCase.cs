using ProductApi.Application.Abstractions.Repositories;
using ProductApi.Application.DTOs;
using ProductApi.Domain;

namespace ProductApi.Application.UseCases.Products;

public class ListProductUseCase(IProductRepository repository) : IListProductUseCase
{
    private readonly IProductRepository _repository = repository;

    public async Task<List<ProductResponse>> ExecuteAsync()
    {
        List<ProductEntity> products = await _repository.GetAllAsync();

        List<ProductResponse> productResponseMapped = products.Select(p => new ProductResponse(
            p.Id,
            p.Name,
            p.Description,
            p.Price
        )).ToList();

        return productResponseMapped;
    }
}
