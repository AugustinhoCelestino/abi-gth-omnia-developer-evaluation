using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.GetByIdUser
{
    public class GetByIdUserCommandValidator : AbstractValidator<GetByIdUserCommand>
    {
        public GetByIdUserCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
        }
    }
}
