namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public List<CartItem>? CartItems { get; set; }
        public bool WasSold { get; set; } = false;
    }
}
