using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.PostProduct;

public class PostProductRequestValidator : AbstractValidator<PostProductRequest>
{
    public PostProductRequestValidator()
    {
        RuleFor(product => product.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(product => product.Price).NotEmpty().WithMessage("Price is required");
        RuleFor(product => product.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(product => product.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(product => product.Image).NotEmpty().WithMessage("Category is required");
        RuleFor(product => product.Rating).SetValidator(new RatingValidator());
    }
}