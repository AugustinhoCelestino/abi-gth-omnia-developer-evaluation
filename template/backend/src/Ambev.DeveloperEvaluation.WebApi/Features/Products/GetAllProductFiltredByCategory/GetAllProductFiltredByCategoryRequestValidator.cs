using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProductFiltredByCategory;

public class GetAllProductFiltredByCategoryRequestValidator : AbstractValidator<GetAllProductFiltredByCategoryRequest>
{
    public GetAllProductFiltredByCategoryRequestValidator()
    {
        RuleFor(x => x.PageNumber).NotEmpty().WithMessage("PageNumber is required");
        RuleFor(x => x.PageSize).NotEmpty().WithMessage("PageNumber is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
    }
}