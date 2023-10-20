using System.Text.Json.Serialization;

namespace CmacPartnerApi.Model;

public class Driver
{
    public string Name { get; set; } = null!;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Number { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Image { get; set; }
}