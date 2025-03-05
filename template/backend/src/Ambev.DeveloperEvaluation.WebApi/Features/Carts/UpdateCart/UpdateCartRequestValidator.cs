using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
{
    public UpdateCartRequestValidator()
    {
        RuleFor(cart => cart.Id).NotEmpty().WithMessage("Cart ID is required");
        RuleFor(cart => cart.UserId).NotEmpty().WithMessage("Cart User ID is required");
        RuleFor(cart => cart.Date).NotEmpty().WithMessage("Cart Date is required");
    }
}