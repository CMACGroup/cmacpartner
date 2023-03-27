namespace CmacPartnerApi.Model;

public class FullBookResponse
{
    public string Id { get; set; } = null!;
    public DateTimeOffset Pickup { get; set; } = DateTimeOffset.Now;
    public Address[] Stops { get; set; } = Array.Empty<Address>();
    public string VehicleType { get; set; } = VehicleTypes.Saloon;
    public int PaxCount { get; set; }
    public string? PaxName { get; set; }
    public string? PaxPhone { get; set; }
    public string Reference { get; set; } = null!;
    public string? Notes { get; set; }
    public Price[] Prices { get; set; } = Array.Empty<Price>();
    public string Status { get; set; } = null!;
    public Driver? Driver { get; set; }
}