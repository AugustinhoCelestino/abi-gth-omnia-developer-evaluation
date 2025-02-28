using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        RuleFor(cart => cart.UserId).NotEmpty();
        RuleFor(cart => cart.Date).NotEmpty();
        RuleFor(cart => cart.Products).SetValidator(new ProductInCartValidator());
    }
}