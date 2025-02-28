using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetByIdCart
{
    public class GetByIdCartCommand : IRequest<GetByIdCartResult>
    {
        public int Id { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new GetByIdCartCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
