using System.Text.Json.Serialization;

namespace TFirewall.Source.FirewallCore.Settings;

public abstract class InspectionSettings
{
    [JsonPropertyName(JsonProperties.IsOn)] public bool IsOn { get; set; } = false;
}