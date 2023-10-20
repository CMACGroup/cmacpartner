using System.Text.Json.Serialization;

namespace CmacPartnerApi.Model;

public class Address
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PickupPoint { get; set; }
    public string Address1 { get; set; } = null!;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Address2 { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Town { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Region { get; set; }
    public string Postcode { get; set; } = null!;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Country { get; set; }
    public string IsoCountry { get; set; } = null!;
    public float Lat { get; set; }
    public float Lng { get; set; }
}