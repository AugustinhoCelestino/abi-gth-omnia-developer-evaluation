using Ambev.DeveloperEvaluation.WebApi.Features.Carts.ViewModel;

public class UpdateCartViewModel
{
    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public List<CartItemViewModel>? Products { get; set; }
}
