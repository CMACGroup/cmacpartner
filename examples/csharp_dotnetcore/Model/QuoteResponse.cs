namespace CmacPartnerApi.Model;

public class QuoteResponse
{
    public QuoteResponseEntry[] Quotes { get; set; } = Array.Empty<QuoteResponseEntry>();
}