using Ambev.DeveloperEvaluation.Application.Model;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.GetAllUser
{
    public class GetAllUserCommand : IRequest<PagnatedResult<List<GetAllUserResult>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string OrderBy { get; set; } = string.Empty;

        public ValidationResultDetail Validate()
        {
            var validator = new GetAllUserCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
