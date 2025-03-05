using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
public record DeleteUserCommand : IRequest<DeleteUserResult>
{
    public Guid Id { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new DeleteUserCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
