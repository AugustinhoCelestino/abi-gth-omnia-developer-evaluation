using Ambev.DeveloperEvaluation.WebApi.Features.Carts.ViewModel;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCart;

public class GetAllCartResponse
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public List<CartItemViewModel>? Products { get; set; }
}
