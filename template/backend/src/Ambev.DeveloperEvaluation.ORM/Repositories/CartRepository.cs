﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;
    public CartRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cart>> GetAllPaginatedAsync(int pageNumber, int pageSize, Expression<Func<Cart, object>> orderBy, bool descending = false, CancellationToken cancellationToken = default)
    {
        var result = _context.Cart.AsNoTracking().AsQueryable();

        result = descending ? result.OrderByDescending(orderBy) : result.OrderBy(orderBy);

        result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        result = result.Include(x => x.CartItems);

        return await result.ToListAsync();
    }

    public async Task<int> GetTotalCount()
    {
        var result = _context.Cart.AsQueryable();

        return await result.CountAsync();
    }

    public async Task<Cart> CreateAsync(Cart model, CancellationToken cancellationToken = default)
    {
        await _context.Cart.AddAsync(model, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return model;
    }

    public async Task<Cart?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Cart.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

}
