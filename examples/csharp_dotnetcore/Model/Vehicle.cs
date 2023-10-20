namespace CmacPartnerApi.Model;

public class Vehicle
{
    public VehicleType Type { get; set; } = VehicleType.Saloon;
    public string[] Attributes { get; set; } = Array.Empty<string>();
}