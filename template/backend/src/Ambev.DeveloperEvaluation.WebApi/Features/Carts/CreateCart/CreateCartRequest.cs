using Ambev.DeveloperEvaluation.WebApi.Features.Carts.ViewModel;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequest
{
    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public List<CartItemViewModel>? Products { get; set; }
}
