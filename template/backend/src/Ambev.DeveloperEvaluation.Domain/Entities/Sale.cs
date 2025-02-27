using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Costumer? CustomerId { get; set; }
        public string? TotalSaleAmount { get; set; }
        public string? BranchId { get; set; }
        public ICollection<SaleItem>? SaleItems { get; set; }
        public bool Cancelled { get; set; }
    }
}
