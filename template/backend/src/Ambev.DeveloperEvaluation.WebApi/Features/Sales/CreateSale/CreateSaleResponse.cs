using Ambev.DeveloperEvaluation.WebApi.Features.Sales.ViewModel;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public string Customer { get; set; } = string.Empty;
    public decimal TotalSaleAmount { get; set; }
    public string Branch { get; set; } = string.Empty;
    public ProductsSaleViewModel Products { get; set; } = new ProductsSaleViewModel();
    public bool Cancelled { get; set; }
}
