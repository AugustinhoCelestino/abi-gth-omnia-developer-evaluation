using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ICartRepository
{
    Task<Cart> CreateAsync(Cart model, CancellationToken cancellationToken = default);
    Task<IEnumerable<Cart>> GetAllPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<Cart?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<int> GetTotalCount();
}
