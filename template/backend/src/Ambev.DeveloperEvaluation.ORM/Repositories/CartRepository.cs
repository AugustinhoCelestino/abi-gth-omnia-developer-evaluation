using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : Repository<Cart, DefaultContext>, ICartRepository
{
    public CartRepository(DefaultContext context) : base(context)
    {

    }
}
