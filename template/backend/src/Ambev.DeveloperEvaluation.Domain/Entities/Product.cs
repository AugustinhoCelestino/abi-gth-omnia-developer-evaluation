using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Description { get; set; }
        public int UnitPrice { get; set; }

    }
}
