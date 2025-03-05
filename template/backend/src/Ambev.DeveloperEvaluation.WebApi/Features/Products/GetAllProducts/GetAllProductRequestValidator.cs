using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProduct;

public class GetAllProductRequestValidator : AbstractValidator<GetAllProductRequest>
{
    public GetAllProductRequestValidator()
    {
        RuleFor(x => x.PageNumber).NotEmpty().WithMessage("PageNumber is required");
        RuleFor(x => x.PageSize).NotEmpty().WithMessage("PageNumber is required");
    }
}