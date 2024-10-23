using TFirewall.Source.FirewallCore.Inspections;
using TFirewall.Source.SystemConfig;
using TFirewall.Source.UserAppConfig.AppState;
using TFirewall.Source.Util;
using Unity;

namespace TFirewall.Source.Middleware;

public class GetRequestInspectorMiddleware
{
    private readonly IUnityContainer _container = IocConfig.GetConfiguredContainer();

    public bool RequestPasses(HttpContext context) => IsNotMalicious(context);

    private bool IsNotMalicious(HttpContext context)
    {
        InspectionsManager inspectionsManager = _container.Resolve<InspectionsManager>();
        // ILogsRepository logsRepository = _container.Resolve<ILogsRepository>();
        IAppState appState = _container.Resolve<IAppState>();

        List<Func<HttpContext, bool>> inspections = ListUtils.ConcatLists(
            inspectionsManager.PanRequestMethodInspectionTypes(),
            inspectionsManager.GetRequestMethodInspectionTypes()
        );

        // logsRepository.CreateLog(
        //     new FirewallLog
        //     {
        //         Id = "null",
        //         Message = "hello",
        //         UserProfile = appState.GetActiveUserProfile(),
        //         Timestamp = DateTime.UtcNow.ToString("o"),
        //         Severity = LogSeverity.Info,
        //     }
        // );
        return inspections.TrueForAll(inspectionJob => inspectionJob(context));
    }

    private bool IsMalicious(HttpContext context) => !IsNotMalicious(context);
}