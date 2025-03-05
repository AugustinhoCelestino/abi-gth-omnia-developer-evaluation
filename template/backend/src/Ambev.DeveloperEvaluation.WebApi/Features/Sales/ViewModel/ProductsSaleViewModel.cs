namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ViewModel;
public class ProductsSaleViewModel
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discont { get; set; }
    public decimal TotalAmount { get; set; }
}
