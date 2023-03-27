namespace CmacPartnerApi.Model;

public class Driver
{
    public string Name { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Image { get; set; }
    public string VehicleDescription { get; set; } = null!;
    public string VehicleNumber { get; set; } = null!;
    public float Lat { get; set; }
    public float Lng { get; set; }
}