using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class RatingValidator : AbstractValidator<Rating>
    {
        public RatingValidator()
        {
            RuleFor(rating => rating.Rate)
                .NotEmpty().WithMessage("Rating is required");
            RuleFor(rating => rating.Count)
                .NotEmpty().WithMessage("Count is required");
        }
    }
}
