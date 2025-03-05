using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetByIdCart;

public class GetByIdCartRequestValidator : AbstractValidator<GetByIdCartRequest>
{
    public GetByIdCartRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required");
    }
}
