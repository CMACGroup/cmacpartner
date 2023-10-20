using System.Text.Json.Serialization;

namespace CmacPartnerApi.Model;

public class QuoteResponseEntry
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OperatorId { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Eta { get; set; }
    
    public Price Price { get; set; } = null!;
}