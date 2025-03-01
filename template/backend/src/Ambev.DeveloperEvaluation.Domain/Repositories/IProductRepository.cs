using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product model, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> GetAllPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<int> GetTotalCount();
}
