using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCart
{
    public class GetAllCartCommand : IRequest<GetAllCartResult>
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public bool OrderByDesc { get; set; } = false;

        public List<string>? OrderBy { get; set; } = new List<string> { "Id", "UserId" };

        public ValidationResultDetail Validate()
        {
            var validator = new GetAllCartCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
