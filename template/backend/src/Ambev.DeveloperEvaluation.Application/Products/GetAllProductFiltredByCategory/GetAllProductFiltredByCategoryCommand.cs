using Ambev.DeveloperEvaluation.Application.Model;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProductFiltredByCategory
{
    public class GetAllProductFiltredByCategoryCommand : IRequest<PagnatedResult<List<GetAllProductFiltredByCategoryResult>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Category { get; set; } = string.Empty;

        public ValidationResultDetail Validate()
        {
            var validator = new GetAllProductFiltredByCategoryCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
