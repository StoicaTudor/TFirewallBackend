using System.Text.Json.Serialization;

namespace TFirewall.Source.FirewallCore.Settings;

public class GeoBlockingInspectionSettings : InspectionSettings
{
    [JsonPropertyName("allowed_countries_codes")] public List<string> AllowedCountriesCodes { get; set; } = [];

    [JsonPropertyName("forbidden_countries_codes")] public List<string> ForbiddenCountriesCodes { get; set; } = [];
}