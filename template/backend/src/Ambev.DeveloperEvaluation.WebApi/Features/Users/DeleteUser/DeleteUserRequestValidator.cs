using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;

public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}
