using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
