using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCart;

public class GetAllCartRequestValidator : AbstractValidator<GetAllCartRequest>
{
    public GetAllCartRequestValidator()
    {
        RuleFor(cart => cart.PageNumber).NotEmpty().WithMessage("PageNumber is required");
        RuleFor(cart => cart.PageSize).NotEmpty().WithMessage("PageNumber is required");
    }
}