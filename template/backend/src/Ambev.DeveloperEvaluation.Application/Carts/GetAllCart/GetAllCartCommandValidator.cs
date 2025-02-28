using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCart
{
    public class GetAllCartCommandValidator : AbstractValidator<GetAllCartCommand>
    {
        public GetAllCartCommandValidator()
        {
            RuleFor(cart => cart.PageNumber).NotEmpty().WithMessage("PageNumber is required"); ;
            RuleFor(cart => cart.PageSize).NotEmpty().WithMessage("PageSize is required"); ;
        }
    }
}
