using System.Text.Json.Serialization;

namespace TFirewall.Source.FirewallCore.Settings;

public class CompositeInspectionSettings : InspectionSettings
{
    [JsonPropertyName(JsonProperties.GeoBlockingSettings)]
    public GeoBlockingInspectionSettings GeoBlockingSettings { get; set; } = new();
    
    [JsonPropertyName(JsonProperties.EndpointTraversalSettings)]
    public EndpointTraversalInspectionSettings EndpointTraversalSettings { get; set; } = new();
    
    [JsonPropertyName(JsonProperties.PortDiscoverySettings)]
    public PortDiscoveryInspectionSettings PortDiscoverySettings { get; set; } = new();
}

/*
 {
    "is_on": true,
    "geo_blocking_settings": {
        "is_on": true,
        "allowed_countries_codes": ["US", "CA", "GB", "AU"],
        "forbidden_countries_codes": ["CN", "RU"]
    },
    "endpoint_traversal_settings": {
        "is_on": true,
        "allowed_paths": ["/home", "/about", "/contact"],
        "mandatory_paths": ["/home", "/profile"],
        "forbidden_paths": ["/admin", "/config"]
    },
    "point_discovery_settings": {
        "is_on": false,
        "allowed_ports": [80, 443, 8080],
        "forbidden_ports": [21, 23, 25]
    }
}
 
 
*/