using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProduct;

public class GetAllProductRequestValidator : AbstractValidator<GetAllProductRequest>
{
    public GetAllProductRequestValidator()
    {
        RuleFor(cart => cart.PageNumber).NotEmpty().WithMessage("PageNumber is required");
        RuleFor(cart => cart.PageSize).NotEmpty().WithMessage("PageNumber is required");
    }
}