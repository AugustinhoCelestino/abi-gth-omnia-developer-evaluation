using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateCartCommandValidator()
    {
        RuleFor(cart => cart.UserId).NotEmpty();
        RuleFor(cart => cart.Id).NotEmpty();
        RuleFor(cart => cart.Date).NotEmpty();
    }
}