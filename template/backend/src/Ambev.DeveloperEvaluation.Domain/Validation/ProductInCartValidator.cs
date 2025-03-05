using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class CartItemValidator : AbstractValidator<CartItem>
    {
        public CartItemValidator()
        {
            RuleFor(product => product.ProductId)
                .NotEmpty()
                .WithMessage("Product must be an Id.");

            RuleFor(product => product.Quantity)
                .NotEmpty()
                .WithMessage("Product must be a Quantity.");
        }
    }
}
