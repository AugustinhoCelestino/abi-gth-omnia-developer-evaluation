using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByIdProducts;

public class GetByIdProductRequestValidator : AbstractValidator<GetByIdProductRequest>
{
    public GetByIdProductRequestValidator()
    {
        RuleFor(c => c.Id).NotEmpty().WithMessage("Id is required");
    }
}