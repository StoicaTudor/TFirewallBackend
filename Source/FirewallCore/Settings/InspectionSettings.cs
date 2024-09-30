using System.Text.Json.Serialization;

namespace TFirewall.Source.FirewallCore.Settings;

public abstract class InspectionSettings
{
    [JsonPropertyName("is_on")] public bool IsOn { get; set; } = false;
}