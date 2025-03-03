using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProductFiltredByCategory
{
    public class GetAllProductFiltredByCategoryCommandValidator : AbstractValidator<GetAllProductFiltredByCategoryCommand>
    {
        public GetAllProductFiltredByCategoryCommandValidator()
        {
            RuleFor(c => c.PageNumber).NotEmpty().WithMessage("PageNumber is required"); ;
            RuleFor(c => c.PageSize).NotEmpty().WithMessage("PageSize is required"); ;
        }
    }
}
