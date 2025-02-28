using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
