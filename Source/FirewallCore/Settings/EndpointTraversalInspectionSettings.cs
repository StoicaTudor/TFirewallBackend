using System.Text.Json.Serialization;

namespace TFirewall.Source.FirewallCore.Settings;

public class EndpointTraversalInspectionSettings : InspectionSettings
{
    [JsonPropertyName("allowed_paths")] public List<string> AllowedPaths { get; set; } = [];
    [JsonPropertyName("mandatory_paths")] public List<string> MandatoryPaths { get; set; } = [];
    [JsonPropertyName("forbidden_paths")] public List<string> ForbiddenPaths { get; set; } = [];
}