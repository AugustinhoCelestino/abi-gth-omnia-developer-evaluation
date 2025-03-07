using Ambev.DeveloperEvaluation.WebApi.Features.Sales.ViewModel;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public string Customer { get; set; } = string.Empty;
    public decimal TotalSaleAmount { get; set; }
    public string Branch { get; set; } = string.Empty;
    public List<ProductsSoldViewModel> Products { get; set; } = [];
    public bool Cancelled { get; set; }
}
