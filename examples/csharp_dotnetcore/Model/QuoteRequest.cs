using System.ComponentModel.DataAnnotations;

namespace CmacPartnerApi.Model;

public class QuoteRequest : IValidatableObject
{
    public DateTimeOffset Pickup { get; set; } = DateTimeOffset.Now;
    
    public Address[] Stops { get; set; } = Array.Empty<Address>();
    
    [Required]
    public Vehicle Vehicle { get; set; } = null!;

    [Range(1, 100)]
    public int PaxCount { get; set; }

    [Range(0, int.MaxValue)]
    public int Distance { get; set; }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Pickup > DateTimeOffset.Now.AddMonths(6))
            yield return new ValidationResult("Can only accept bookings that depart in the next 6 months",
                new[] { nameof(Pickup) });
        
        if (Stops.Length < 2)
            yield return new ValidationResult("There must be at least 2 stops i.e. pickup and drop off",
                new[] { nameof(Stops) });
    }
}