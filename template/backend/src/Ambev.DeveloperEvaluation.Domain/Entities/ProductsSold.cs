namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class ProductsSold
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public int SaleId { get; set; }
        public Sale Sale { get; set; } = new Sale();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discont { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
