using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        RuleFor(cart => cart.UserId).NotEmpty().WithMessage("Cart User ID is required");
        RuleFor(cart => cart.Date).NotEmpty().WithMessage("Cart Date is required"); ;
        RuleFor(cart => cart.Products).SetValidator(new ProductInCartValidator());
    }
}