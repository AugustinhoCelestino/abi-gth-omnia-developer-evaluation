using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
        }
    }
}
