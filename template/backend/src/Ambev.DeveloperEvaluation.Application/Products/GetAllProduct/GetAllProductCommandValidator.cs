using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProduct
{
    public class GetAllProductCommandValidator : AbstractValidator<GetAllProductCommand>
    {
        public GetAllProductCommandValidator()
        {
            RuleFor(x => x.PageNumber).NotEmpty().WithMessage("PageNumber is required"); ;
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("PageSize is required"); ;
        }
    }
}
