namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ViewModel;
public class AddressViewModel
{
    public string City { get; set; } = String.Empty;
    public string Street { get; set; } = String.Empty;
    public int Number { get; set; }
    public string Zipcode { get; set; } = String.Empty;
    public Geolocation Geolocation { get; set; } = new Geolocation();
}
public class Geolocation
{
    public string Lat { get; set; } = String.Empty;
    public string Long { get; set; } = String.Empty;
}