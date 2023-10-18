namespace CmacPartnerApi.Model;

public class FullBookResponse
{
    public string Id { get; set; } = null!;
    public DateTimeOffset Pickup { get; set; } = DateTimeOffset.Now;
    public Address[] Stops { get; set; } = Array.Empty<Address>();
    public string VehicleType { get; set; } = null!;
    public int PaxCount { get; set; }
    public string Reference { get; set; } = null!;
    public Price[] Prices { get; set; } = Array.Empty<Price>();
    public string Status { get; set; } = null!;
    public VehicleType? Vehicle { get; set; }
    public float? Lat { get; set; }
    public float? Lng { get; set; }
    public PassengerType? Passenger { get; set; }
}