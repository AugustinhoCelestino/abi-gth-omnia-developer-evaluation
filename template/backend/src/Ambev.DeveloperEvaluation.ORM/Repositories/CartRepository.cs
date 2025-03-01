using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;
    public CartRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cart>> GetAllPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var result = _context.Cart.AsNoTracking().AsQueryable();

        result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return await result.ToListAsync();
    }

    public async Task<int> GetTotalCount()
    {
        var result = _context.Cart.AsQueryable();

        return await result.CountAsync();
    }

    public async Task<Cart> CreateAsync(Cart model, CancellationToken cancellationToken = default)
    {
        await _context.Cart.AddAsync(model, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return model;
    }

    public async Task<Cart?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Cart.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

}
