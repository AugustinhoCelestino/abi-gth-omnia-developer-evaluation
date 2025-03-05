using Ambev.DeveloperEvaluation.Domain.Entities;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);

    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<User>> GetAllPaginatedAsync(int pageNumber, int pageSize, Expression<Func<User, object>> orderBy, bool descending = false, CancellationToken cancellationToken = default);
    Task<int> GetTotalCount();
}
