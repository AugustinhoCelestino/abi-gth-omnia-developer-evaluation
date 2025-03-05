using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.CartId).NotEmpty().WithMessage("Sale CartId is required");
        RuleFor(sale => sale.Customer).NotEmpty().WithMessage("Sale Customer is required");
        RuleFor(sale => sale.Branch).NotEmpty().WithMessage("Sale Branch is required");
    }
}