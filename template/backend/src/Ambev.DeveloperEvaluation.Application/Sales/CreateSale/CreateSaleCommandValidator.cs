using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
            RuleFor(sale => sale.CartId).NotEmpty().WithMessage("Sale CartId is required");
            RuleFor(sale => sale.Customer).NotEmpty().WithMessage("Sale Customer is required");
            RuleFor(sale => sale.Branch).NotEmpty().WithMessage("Sale Branch is required");
        }
    }
}