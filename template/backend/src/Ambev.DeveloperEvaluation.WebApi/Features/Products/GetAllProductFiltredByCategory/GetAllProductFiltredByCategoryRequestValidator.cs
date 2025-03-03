using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProductFiltredByCategory;

public class GetAllProductFiltredByCategoryRequestValidator : AbstractValidator<GetAllProductFiltredByCategoryRequest>
{
    public GetAllProductFiltredByCategoryRequestValidator()
    {
        RuleFor(c => c.PageNumber).NotEmpty().WithMessage("PageNumber is required");
        RuleFor(c => c.PageSize).NotEmpty().WithMessage("PageNumber is required");
    }
}