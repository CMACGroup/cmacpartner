using System.ComponentModel.DataAnnotations;

namespace CmacPartnerApi.Model;

public class QuoteRequest : IValidatableObject
{
    public DateTimeOffset Pickup { get; set; } = DateTimeOffset.Now;
    
    public Address[] Stops { get; set; } = Array.Empty<Address>();
    
    [Required]
    public string VehicleType { get; set; } = VehicleTypes.Saloon;
    
    [Range(1, 100)]
    public int PaxCount { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Pickup > DateTimeOffset.Now.AddMonths(6))
            yield return new ValidationResult("Can only accept bookings within the next 6 months",
                new[] { nameof(Pickup) });
        
        if (Stops.Length < 2)
            yield return new ValidationResult("There must be at least 2 stops i.e. start and end locations",
                new[] { nameof(Stops) });
    }
}