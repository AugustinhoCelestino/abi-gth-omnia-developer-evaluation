using FluentValidation;

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
