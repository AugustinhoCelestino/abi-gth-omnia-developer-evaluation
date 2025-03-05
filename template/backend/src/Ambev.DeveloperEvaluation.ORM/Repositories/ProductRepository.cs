using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;
    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllPaginatedAsync(int pageNumber, int pageSize, Expression<Func<Product, object>> orderBy, bool descending = false, CancellationToken cancellationToken = default)
    {
        var result = _context.Products.AsNoTracking().AsQueryable();

        result = descending ? result.OrderByDescending(orderBy) : result.OrderBy(orderBy);

        result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        result = result.Include(x => x.Rating);

        return await result.ToListAsync(cancellationToken: cancellationToken);
    }
    public async Task<int> GetTotalCount()
    {
        var result = _context.Products.AsQueryable();

        return await result.CountAsync();
    }
    public async Task<Product> CreateAsync(Product model, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(model, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return model;
    }
    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Include(x => x.Rating).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }
    public async Task<Product> UpdateAsync(Product model, CancellationToken cancellationToken = default)
    {
        var modelToUpdate = await GetByIdAsync(model.Id, cancellationToken);

        if (modelToUpdate is not null)
        {
            modelToUpdate.Rating = model.Rating;
            _context.Products.Entry(modelToUpdate).CurrentValues.SetValues(model);

            await _context.SaveChangesAsync(cancellationToken);
        }

        return model;
    }
    public async Task<bool> DeleteAsync(Product model, CancellationToken cancellationToken = default)
    {
        _context.Products.Remove(model);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
    public async Task<List<string?>> GetAllCategories(CancellationToken cancellationToken = default)
    {
        var result =
            _context.Products.Select(s => s.Category)
            .Distinct();

        return await result.ToListAsync(cancellationToken: cancellationToken);
    }
    public async Task<IEnumerable<Product>> GetAllPaginatedFiltredByCategoryAsync(int pageNumber, int pageSize, string category, CancellationToken cancellationToken = default)
    {
        var result = _context.Products.AsNoTracking().AsQueryable();

        result = result.Where(x => x.Category == category);

        result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        result = result.Include(x => x.Rating);

        return await result.ToListAsync(cancellationToken: cancellationToken);
    }

}
