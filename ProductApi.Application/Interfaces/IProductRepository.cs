using ProductApi.Domain;

namespace ProductApi.Application.Abstractions.Repositories;
public interface IProductRepository
{
    Task AddAsync(ProductEntity product);
    Task<ProductEntity?> GetByIdAsync(Guid id);
    Task<List<ProductEntity>> GetAllAsync();
    Task UpdateAsync(ProductEntity product);
    Task DeleteAsync(Guid id);
}
