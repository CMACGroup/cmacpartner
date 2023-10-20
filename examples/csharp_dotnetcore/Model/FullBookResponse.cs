using System.Text.Json.Serialization;

namespace CmacPartnerApi.Model;

public class FullBookResponse
{
    public string Id { get; set; } = null!;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OperatorId { get; set; }
    public DateTimeOffset Pickup { get; set; } = DateTimeOffset.Now;
    public Address[] Stops { get; set; } = Array.Empty<Address>();
    public int PaxCount { get; set; }
    public string Reference { get; set; } = null!;
    public Price[] Prices { get; set; } = Array.Empty<Price>();
    public string Status { get; set; } = BookingStatus.Booked;
    public VehicleWithDetails? Vehicle { get; set; }
    public float? Lat { get; set; }
    public float? Lng { get; set; }
    public Passenger? Passenger { get; set; }
}