using System.Text.Json.Serialization;

namespace CmacPartnerApi.Model;

public class Price
{
    public PriceType Type { get; set; } = PriceType.JourneyNet;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }
    public int Amount { get; set; }
    public string Currency { get; set; } = Currencies.GBP;
    public KeyValuePair<string, string>[] Attributes { get; set; } = Array.Empty<KeyValuePair<string, string>>();
}