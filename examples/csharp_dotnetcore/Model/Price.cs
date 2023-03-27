namespace CmacPartnerApi.Model;

public class Price
{
    public string Type { get; set; } = PriceTypes.JourneyNet;
    public string? Description { get; set; }
    public int Amount { get; set; }
    public string Currency { get; set; } = PriceCurrencies.GBP;
}