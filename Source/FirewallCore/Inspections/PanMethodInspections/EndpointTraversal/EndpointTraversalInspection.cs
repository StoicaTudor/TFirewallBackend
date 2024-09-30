using Microsoft.Extensions.Logging.Configuration;
using Microsoft.IdentityModel.Tokens;
using TFirewall.Source.FirewallCore.Settings;
using TFirewall.Source.Util.ExtensionMethods;

namespace TFirewall.Source.FirewallCore.Inspections.PanMethodInspections.EndpointTraversal;

public class EndpointTraversalInspection : IInspection<EndpointTraversalInspectionSettings>
{
    public bool InspectionIsCompliant(HttpContext context, EndpointTraversalInspectionSettings inspectionSettings) =>
        DoesNotContainForbiddenPaths(context, inspectionSettings)
        && ContainsAtLeast1AllowedPath(context, inspectionSettings)
        && HasAllMandatoryPaths(context, inspectionSettings);

    private static bool DoesNotContainForbiddenPaths(
        HttpContext context,
        EndpointTraversalInspectionSettings inspectionSettings)
    {
        return context.Request.Path.HasValue
               && inspectionSettings.ForbiddenPaths.NoneRespects(
                   keyword => context.Request.Path.Value.Contains(keyword));
    }

    private static bool ContainsAtLeast1AllowedPath(
        HttpContext context,
        EndpointTraversalInspectionSettings inspectionSettings)
    {
        return inspectionSettings.AllowedPaths.IsNullOrEmpty() || context.Request.Path.HasValue
            && inspectionSettings.AllowedPaths.Any(keyword => context.Request.Path.Value.Contains(keyword));
    }

    private static bool HasAllMandatoryPaths(
        HttpContext context,
        EndpointTraversalInspectionSettings inspectionSettings)
    {
        return context.Request.Path.HasValue
               && inspectionSettings.MandatoryPaths.TrueForAll(keyword => context.Request.Path.Value.Contains(keyword));
    }
}