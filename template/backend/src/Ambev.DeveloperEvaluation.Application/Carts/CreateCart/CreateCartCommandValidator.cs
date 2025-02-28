using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartCommandValidator()
    {
        RuleFor(cart => cart.UserId).NotEmpty();
        RuleFor(cart => cart.Date).NotEmpty();
        RuleFor(cart => cart.Products).SetValidator(new ProductInCartValidator());
    }
}