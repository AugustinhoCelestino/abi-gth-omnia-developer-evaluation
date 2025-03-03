using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;
    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var result = _context.Product.AsNoTracking().AsQueryable();

        result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return await result.ToListAsync();
    }
    public async Task<int> GetTotalCount()
    {
        var result = _context.Product.AsQueryable();

        return await result.CountAsync();
    }
    public async Task<Product> CreateAsync(Product model, CancellationToken cancellationToken = default)
    {
        await _context.Product.AddAsync(model, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return model;
    }

    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Product.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }
}
