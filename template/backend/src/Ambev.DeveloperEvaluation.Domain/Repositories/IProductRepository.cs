using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product model, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Product model, CancellationToken cancellationToken = default);
    Task<List<string?>> GetAllCategories(CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> GetAllPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<int> GetTotalCount();
    Task<Product> UpdateAsync(Product model, CancellationToken cancellationToken = default);
}
