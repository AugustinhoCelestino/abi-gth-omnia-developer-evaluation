using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetAllUser;

public class GetAllUserRequestValidator : AbstractValidator<GetAllUserRequest>
{
    public GetAllUserRequestValidator()
    {
        RuleFor(x => x.PageNumber).NotEmpty().WithMessage("PageNumber is required");
        RuleFor(x => x.PageSize).NotEmpty().WithMessage("PageNumber is required");
    }
}