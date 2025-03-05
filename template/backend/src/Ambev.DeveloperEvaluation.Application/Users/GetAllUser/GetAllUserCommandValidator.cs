using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.GetAllUser
{
    public class GetAllUserCommandValidator : AbstractValidator<GetAllUserCommand>
    {
        public GetAllUserCommandValidator()
        {
            RuleFor(x => x.PageNumber).NotEmpty().WithMessage("PageNumber is required"); ;
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("PageSize is required"); ;
        }
    }
}
