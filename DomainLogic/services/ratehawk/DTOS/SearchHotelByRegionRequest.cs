
using System.Text.Json;
using System.Text.Json.Serialization;
using DomainLogic.services.ratehawk.DTOS;
using Newtonsoft.Json.Converters;

namespace DomainLogic.services.ratehawk;

public class JsonConverterWithEnumAsString<T>
{
    public static string SerializeWithEnumConverter(T request)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };
        return JsonSerializer.Serialize(request, options);
    }
}

public record SearchHotelByRegionRequest
{
    public int region_id { get; set; }
    public string checkin { get; set; }
    public string checkout { get; set; }
    public LanguagesEnum language { get; set; }
    public List<Guest> guests { get; set; }
}