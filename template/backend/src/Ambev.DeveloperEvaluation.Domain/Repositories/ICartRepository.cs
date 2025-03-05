using Ambev.DeveloperEvaluation.Domain.Entities;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ICartRepository
{
    Task<Cart> CreateAsync(Cart model, CancellationToken cancellationToken = default);
    Task<IEnumerable<Cart>> GetAllPaginatedAsync(int pageNumber, int pageSize, Expression<Func<Cart, object>> orderBy, bool descending, CancellationToken cancellationToken = default);
    Task<Cart?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<int> GetTotalCount();
    Task<Cart> UpdateAsync(Cart model, CancellationToken cancellationToken = default);
}
