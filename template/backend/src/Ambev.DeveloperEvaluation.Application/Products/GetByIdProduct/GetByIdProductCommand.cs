using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetByIdProduct
{
    public class GetByIdProductCommand : IRequest<GetByIdProductResult>
    {
        public int Id { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new GetByIdProductCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
