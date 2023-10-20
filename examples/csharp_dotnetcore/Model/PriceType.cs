using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CmacPartnerApi.Model;

[DebuggerDisplay("{_value}")]
[JsonConverter(typeof(PriceTypeConverter))]
public record struct PriceType : IEquatable<string> 
{
    private readonly string _value;
    
    public static readonly PriceType JourneyNet = new("JourneyNet");
    public static readonly PriceType JourneyTax = new("JourneyTax");
    public static readonly PriceType Waiting = new("Waiting");
    public static readonly PriceType LeadMiles = new("LeadMiles");
    public static readonly PriceType Toll = new("Toll");
    public static readonly PriceType Parking = new("Parking");
    public static readonly PriceType GreenFee = new("GreenFee");
    public static readonly PriceType MeetAndGreet = new("MeetAndGreet");
    public static readonly PriceType Soilage = new("Soilage");
    public static readonly PriceType Miscellaneous = new("Miscellaneous");
    
    public PriceType(object value)
    {
        if (value is not string priceTypeValue || string.IsNullOrEmpty(priceTypeValue))
        {
            throw new ArgumentException("Price type must be a non-empty string", nameof(value));
        }
        string[] priceTypeNames =
        {
            "JourneyNet",
            "JourneyTax",
            "Waiting",
            "LeadMiles",
            "Toll",
            "Parking",
            "GreenFee",
            "MeetAndGreet",
            "Soilage",
            "Miscellaneous",
        };
        
        for (var i = 0; i < priceTypeNames.Length; i++)
        {
            if (string.Equals(priceTypeNames[i], priceTypeValue, StringComparison.OrdinalIgnoreCase))
            {
                _value = priceTypeNames[i];
                return;
            }
        }
        
        throw new ArgumentException($"{value} is not a valid price type");
    }
    
    public bool Equals(string? other)
    {
        return string.Equals(_value, other, StringComparison.OrdinalIgnoreCase);
    }
    
    public override int GetHashCode()
    {
        return _value?.GetHashCode() ?? 0;
    }
    
    public static implicit operator PriceType(string s)
    {
        return new PriceType(s);
    }
    
    public static implicit operator string(PriceType s)
    {
        return s._value;
    }

    public override string ToString()
    {
        return _value;
    }
}

public class PriceTypeConverter : JsonConverter<PriceType>
{
    public override PriceType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new PriceType(reader.GetString() ?? string.Empty);
    }

    public override void Write(Utf8JsonWriter writer, PriceType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}