using TFirewall.Source.FirewallCore.Settings;

namespace TFirewall.Source.FirewallCore.Inspections.PanMethodInspections.PortDiscovery;

public class PortDiscoveryInspection : IInspection<PortDiscoveryInspectionSettings>
{
    public bool InspectionIsCompliant(HttpContext context, PortDiscoveryInspectionSettings inspectionSettings) =>
        IsAnAllowedPort(context, inspectionSettings) && IsNotForbiddenPort(context, inspectionSettings);

    private static bool IsAnAllowedPort(HttpContext context, PortDiscoveryInspectionSettings inspectionSettings)
    {
        int? port = context.Request.Host.Port;
        if (!port.HasValue)
            return false;

        // return inspectionSettings.AllowedPorts.Contains(port.Value);
        return true;
    }

    private static bool IsNotForbiddenPort(HttpContext context, PortDiscoveryInspectionSettings inspectionSettings)
    {
        int? port = context.Request.Host.Port;
        if (!port.HasValue)
            return false;

        return !inspectionSettings.ForbiddenPorts.Contains(port.Value);
    }
}