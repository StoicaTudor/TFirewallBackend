using System.Text.Json.Serialization;

namespace TFirewall.Source.FirewallCore.Settings;

public class EndpointTraversalInspectionSettings : InspectionSettings
{
    [JsonPropertyName(JsonProperties.AllowedPaths)] public List<string> AllowedPaths { get; set; } = [];
    [JsonPropertyName(JsonProperties.MandatoryPaths)] public List<string> MandatoryPaths { get; set; } = [];
    [JsonPropertyName(JsonProperties.ForbiddenPaths)] public List<string> ForbiddenPaths { get; set; } = [];
}