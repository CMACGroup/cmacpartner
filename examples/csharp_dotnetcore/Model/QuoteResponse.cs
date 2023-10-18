namespace CmacPartnerApi.Model;

public class QuoteResponse
{
    public int? Eta { get; set; }
    public Price Price { get; set; } = null!;
}