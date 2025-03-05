namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProduct;

public class GetAllProductRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string OrderBy { get; set; } = string.Empty;
}
