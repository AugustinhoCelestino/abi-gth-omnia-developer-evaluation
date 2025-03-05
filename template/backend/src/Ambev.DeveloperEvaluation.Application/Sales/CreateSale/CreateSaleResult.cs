using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleResult
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public bool Cancelled { get; set; }
        public List<ProductsSold> ProductsSold { get; set; } = [];
        public decimal TotalSaleAmount { get; set; }
    }
}
