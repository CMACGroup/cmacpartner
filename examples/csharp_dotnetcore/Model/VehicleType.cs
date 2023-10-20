using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CmacPartnerApi.Model;

[DebuggerDisplay("{_value}")]
[JsonConverter(typeof(VehicleTypeNameConverter))]
public record struct VehicleType : IEquatable<string> 
{
    private readonly string _value;
    
    public static readonly VehicleType Saloon = new("Saloon");
    public static readonly VehicleType WAV = new("WAV");
    public static readonly VehicleType MPV = new("MPV");
    public static readonly VehicleType Minibus = new("Minibus");
    public static readonly VehicleType Exec = new("Exec");
    public static readonly VehicleType BlackCab = new("BlackCab");
    
    public VehicleType(object value)
    {
        if (value is not string vehicleTypeValue || string.IsNullOrEmpty(vehicleTypeValue))
        {
            throw new ArgumentException("Vehicle type must be a non-empty string", nameof(value));
        }
        string[] vehicleTypeNames =
        {
            "Saloon",
            "WAV",
            "MPV",
            "Minibus",
            "Exec",
            "BlackCab",
        };
        
        for (var i = 0; i < vehicleTypeNames.Length; i++)
        {
            if (string.Equals(vehicleTypeNames[i], vehicleTypeValue, StringComparison.OrdinalIgnoreCase))
            {
                _value = vehicleTypeNames[i];
                return;
            }
        }
        
        throw new ArgumentException($"{value} is not a valid vehicle type");
    }
    
    public bool Equals(string? other)
    {
        return string.Equals(_value, other, StringComparison.OrdinalIgnoreCase);
    }
    
    public override int GetHashCode()
    {
        return _value?.GetHashCode() ?? 0;
    }
    
    public static implicit operator VehicleType(string s)
    {
        return new VehicleType(s);
    }
    
    public static implicit operator string(VehicleType s)
    {
        return s._value;
    }

    public override string ToString()
    {
        return _value;
    }
}

public class VehicleTypeNameConverter : JsonConverter<VehicleType>
{
    public override VehicleType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new VehicleType(reader.GetString() ?? string.Empty);
    }

    public override void Write(Utf8JsonWriter writer, VehicleType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}