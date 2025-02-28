using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProduct
{
    public class GetAllProductCommandValidator : AbstractValidator<GetAllProductCommand>
    {
        public GetAllProductCommandValidator()
        {
            RuleFor(c => c.PageNumber).NotEmpty().WithMessage("PageNumber is required"); ;
            RuleFor(c => c.PageSize).NotEmpty().WithMessage("PageSize is required"); ;
        }
    }
}
