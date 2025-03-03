using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProduct;

public class GetAllProductRequestValidator : AbstractValidator<GetAllProductRequest>
{
    public GetAllProductRequestValidator()
    {
        RuleFor(c => c.PageNumber).NotEmpty().WithMessage("PageNumber is required");
        RuleFor(c => c.PageSize).NotEmpty().WithMessage("PageNumber is required");
    }
}