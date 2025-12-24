using ProductApi.Application.Abstractions.Repositories;
using ProductApi.Domain;

namespace ProductApi.Application.UseCases.Products;

public class DeleteProductUseCase(IProductRepository repository) : IDeleteProductUseCase
{
    private readonly IProductRepository _repository = repository;

    public async Task ExecuteAsync(Guid id)
    {
        ProductEntity product = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Produto não encontrado");

        await _repository.DeleteAsync(product.Id);
        return;
    }
}
