using Microsoft.EntityFrameworkCore;
using ProductApi.Domain;

namespace ProductApi.Infrastructure.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<ProductEntity> Products => Set<ProductEntity>();
}
