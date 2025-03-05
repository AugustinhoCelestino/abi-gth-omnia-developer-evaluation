using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetByIdCart
{
    public class GetByIdCartResult
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public List<CartItem>? CartItems { get; set; }
    }
}
