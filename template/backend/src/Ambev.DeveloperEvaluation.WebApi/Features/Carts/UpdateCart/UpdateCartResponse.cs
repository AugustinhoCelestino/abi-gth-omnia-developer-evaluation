using Ambev.DeveloperEvaluation.WebApi.Features.Carts.ViewModel;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartResponse
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public List<CartItemViewModel>? Products { get; set; }
}
