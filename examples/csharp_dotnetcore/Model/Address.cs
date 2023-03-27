namespace CmacPartnerApi.Model;

public class Address
{
    public string? PickupPoint { get; set; }
    public string Address1 { get; set; } = null!;
    public string? Address2 { get; set; }
    public string? Town { get; set; }
    public string? Region { get; set; }
    public string? Postcode { get; set; }
    public string? Country { get; set; }
    public string IsoCountry { get; set; } = null!;
    public float Lat { get; set; }
    public float Lng { get; set; }
}