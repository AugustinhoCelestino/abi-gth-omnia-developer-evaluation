using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;
public class UserRepository : IUserRepository
{
    private readonly DefaultContext _context;
    public UserRepository(DefaultContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> GetAllPaginatedAsync(int pageNumber, int pageSize, Expression<Func<User, object>> orderBy, bool descending = false, CancellationToken cancellationToken = default)
    {
        var result = _context.Users.AsNoTracking().AsQueryable();

        result = descending ? result.OrderByDescending(orderBy) : result.OrderBy(orderBy);

        result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return await result.ToListAsync(cancellationToken: cancellationToken);
    }
    public async Task<int> GetTotalCount()
    {
        var result = _context.Users.AsQueryable();

        return await result.CountAsync();
    }
    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }
    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await GetByIdAsync(id, cancellationToken);
        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
