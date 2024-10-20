using System.Text.Json.Serialization;

namespace TFirewall.Source.FirewallCore.Settings;

public class GeoBlockingInspectionSettings : InspectionSettings
{
    [JsonPropertyName(JsonProperties.AllowedCountriesCodes)] public List<string> AllowedCountriesCodes { get; set; } = [];

    [JsonPropertyName(JsonProperties.ForbiddenCountriesCodes)] public List<string> ForbiddenCountriesCodes { get; set; } = [];
}