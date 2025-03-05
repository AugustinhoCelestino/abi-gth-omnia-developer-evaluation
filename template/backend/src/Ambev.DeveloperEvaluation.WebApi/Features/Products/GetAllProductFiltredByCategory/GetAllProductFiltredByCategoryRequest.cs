namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProductFiltredByCategory;

public class GetAllProductFiltredByCategoryRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Category {  get; set; }
}
