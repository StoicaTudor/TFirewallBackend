using System.Text.Json.Serialization;

namespace TFirewall.Source.FirewallCore.Settings;

public class PortDiscoveryInspectionSettings : InspectionSettings
{
    [JsonPropertyName("allowed_ports")] public List<int> AllowedPorts { get; set; } = [];
    [JsonPropertyName("forbidden_ports")] public List<int> ForbiddenPorts { get; set; } = [];
}