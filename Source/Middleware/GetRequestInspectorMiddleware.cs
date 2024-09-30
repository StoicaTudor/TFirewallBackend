using TFirewall.Source.FirewallCore.Inspections;
using TFirewall.Source.SystemConfig;
using TFirewall.Source.Util;
using Unity;

namespace TFirewall.Source.Middleware;

public class GetRequestInspectorMiddleware
{
    private readonly IUnityContainer _container = IocConfig.GetConfiguredContainer();

    public bool RequestPasses(HttpContext context) => IsMalicious(context);

    private bool IsMalicious(HttpContext context)
    {
        InspectionsManager inspectionsManager = _container.Resolve<InspectionsManager>();
        
        List<Func<HttpContext, bool>> inspections = ListUtils.ConcatLists(
            inspectionsManager.PanRequestMethodInspectionTypes(),
            inspectionsManager.GetRequestMethodInspectionTypes()
        );

        return inspections.Any(inspectionJob => inspectionJob(context));
    }
}