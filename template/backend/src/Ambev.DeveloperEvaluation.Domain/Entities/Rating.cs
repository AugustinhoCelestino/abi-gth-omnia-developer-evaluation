namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal Rate { get; set; }
        public int Count { get; set; }
    }
}
