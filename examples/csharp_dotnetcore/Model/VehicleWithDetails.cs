namespace CmacPartnerApi.Model;

public class VehicleWithDetails : Vehicle
{
    public string? Vrn { get; set; }
    public string? Description { get; set; }
    public Driver? Driver { get; set; }
}