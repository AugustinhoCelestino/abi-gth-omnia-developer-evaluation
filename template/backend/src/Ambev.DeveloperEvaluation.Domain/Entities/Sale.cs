namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Customer { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public bool Cancelled { get; set; }
        public List<CartItem> CartItems { get; set; } = [];

    }
}
