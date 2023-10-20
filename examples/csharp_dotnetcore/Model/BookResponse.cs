using System.Text.Json.Serialization;

namespace CmacPartnerApi.Model;

public class BookResponse
{
    public string Id { get; set; } = null!;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Eta { get; set; }
}