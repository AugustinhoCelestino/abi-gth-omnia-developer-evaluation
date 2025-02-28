using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>  where TEntity : class where TContext : DbContext
    {
        protected readonly TContext _context;
        protected Repository(TContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> DbSet => _context.Set<TEntity>();


        public async Task<IEnumerable<TEntity>> GetAllPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var result = DbSet.AsNoTracking().AsQueryable();

            result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await result.ToListAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity model, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return model;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await DbSet.AsQueryable().AsNoTracking().Where(where).ToListAsync();

            return result;
        }

        public async Task<TEntity> UpdateAsync(TEntity model, CancellationToken cancellationToken = default)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.Update(model);

            await _context.SaveChangesAsync(cancellationToken);

            return model;
        }

        public async Task<TEntity> DeleteAsync(TEntity model, CancellationToken cancellationToken = default)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync(cancellationToken);

            return model;
        }

        public async Task<IEnumerable<TEntity>> Select(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes)
        {
            var result = DbSet.AsQueryable().AsNoTracking();

            result = result.Where(where);

            if (includes != null)
            {
                result = includes(result);
            }

            return await result.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> SelectMany(List<Expression<Func<TEntity, bool>>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes)
        {
            var result = DbSet.AsQueryable().AsNoTracking();

            foreach (var filter in where)
            {
                result = result.Where(filter);
            }

            if (includes != null)
            {
                result = includes(result);
            }

            return await result.ToListAsync();

        }

        public async Task<TEntity?> FindNoTrackingAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(where);
        }




        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
