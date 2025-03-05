using Ambev.DeveloperEvaluation.Domain.Entities;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product model, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Product model, CancellationToken cancellationToken = default);
    Task<List<string?>> GetAllCategories(CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> GetAllPaginatedAsync(int pageNumber, int pageSize, Expression<Func<Product, object>> orderBy, bool descending, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> GetAllPaginatedFiltredByCategoryAsync(int pageNumber, int pageSize, string category, CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<int> GetTotalCount();
    Task<Product> UpdateAsync(Product model, CancellationToken cancellationToken = default);
}
