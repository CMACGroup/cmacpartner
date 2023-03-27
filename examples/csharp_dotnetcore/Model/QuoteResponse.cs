namespace CmacPartnerApi.Model;

public class QuoteResponse
{
    public int? Eta { get; set; }
    public Price Price { get; set; } = null!;
    public string VehicleType { get; set; } = null!;
}