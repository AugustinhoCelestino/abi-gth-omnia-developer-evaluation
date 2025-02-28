﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity model, CancellationToken cancellationToken = default);
        Task<TEntity> DeleteAsync(TEntity model, CancellationToken cancellationToken = default);
        Task<TEntity?> FindNoTrackingAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetAllAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllPaginatedAsync(int pageSize, int pageNumber, System.Linq.Expressions.Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> Select(System.Linq.Expressions.Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes);
        Task<IEnumerable<TEntity>> SelectMany(List<System.Linq.Expressions.Expression<Func<TEntity, bool>>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes);
        Task<TEntity> UpdateAsync(TEntity model, CancellationToken cancellationToken = default);
    }
}
