namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ViewModels;

public class UpdateProductViewModel
{
    public string? Title { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? Image { get; set; }
    public RatingViewModel? Rating { get; set; }
}