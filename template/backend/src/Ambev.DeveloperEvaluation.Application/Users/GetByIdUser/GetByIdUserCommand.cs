using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.GetByIdUser
{
    public class GetByIdUserCommand : IRequest<GetByIdUserResult>
    {
        public Guid Id { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new GetByIdUserCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
