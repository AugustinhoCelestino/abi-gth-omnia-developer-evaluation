using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetByIdUser;

public class GetByIdUserRequestValidator : AbstractValidator<GetByIdUserRequest>
{
    public GetByIdUserRequestValidator()
    {
        RuleFor(c => c.Id).NotEmpty().WithMessage("Id is required");
    }
}