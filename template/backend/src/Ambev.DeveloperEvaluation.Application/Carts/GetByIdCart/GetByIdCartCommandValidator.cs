using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetByIdCart
{
    public class GetByIdCartCommandValidator : AbstractValidator<GetByIdCartCommand>
    {
        public GetByIdCartCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
        }
    }
}
