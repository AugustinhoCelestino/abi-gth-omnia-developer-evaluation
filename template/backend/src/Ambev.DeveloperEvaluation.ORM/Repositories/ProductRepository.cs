using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : Repository<Product, DefaultContext>, IProductRepository
{
    public ProductRepository(DefaultContext context) : base(context)
    {

    }
}
