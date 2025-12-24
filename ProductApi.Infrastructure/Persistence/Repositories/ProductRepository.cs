using Microsoft.EntityFrameworkCore;
using ProductApi.Application.Abstractions.Repositories;
using ProductApi.Domain;
using ProductApi.Infrastructure.Persistence.Context;

namespace ProductApi.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ProductEntity product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task<ProductEntity?> GetByIdAsync(Guid id) =>
        await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<List<ProductEntity>> GetAllAsync() =>
        await _context.Products.AsNoTracking().ToListAsync();

    public async Task UpdateAsync(ProductEntity product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        ProductEntity? productToDeleteId = await GetByIdAsync(id);
        if (productToDeleteId is null)
            return;
        _context.Products.Remove(productToDeleteId);
        await _context.SaveChangesAsync();
    }
}
