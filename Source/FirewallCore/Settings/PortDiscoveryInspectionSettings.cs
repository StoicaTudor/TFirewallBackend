using System.Text.Json.Serialization;

namespace TFirewall.Source.FirewallCore.Settings;

public class PortDiscoveryInspectionSettings : InspectionSettings
{
    [JsonPropertyName(JsonProperties.AllowedPorts)] public List<int> AllowedPorts { get; set; } = [];
    [JsonPropertyName(JsonProperties.ForbiddenPorts)] public List<int> ForbiddenPorts { get; set; } = [];
}