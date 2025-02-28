using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetByIdCart;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class GetByIdCartRequestValidator : AbstractValidator<GetByIdCartRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public GetByIdCartRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
