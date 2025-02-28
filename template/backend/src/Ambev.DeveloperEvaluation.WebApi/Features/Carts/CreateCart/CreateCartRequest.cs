using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequest
{
    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public CartItem Products { get; set; } = new CartItem();
}
