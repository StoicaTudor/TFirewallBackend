using TFirewall.Source.FirewallCore.Inspections.PanMethodInspections.EndpointTraversal;
using TFirewall.Source.FirewallCore.Inspections.PanMethodInspections.GeoBlocking;
using TFirewall.Source.FirewallCore.Inspections.PanMethodInspections.PortDiscovery;
using TFirewall.Source.FirewallCore.Settings;
using TFirewall.Source.SystemConfig;
using TFirewall.Source.UserAppConfig.AppState;
using Unity;

namespace TFirewall.Source.FirewallCore.Inspections
{
    public class InspectionsManager
    {
        private readonly IUnityContainer _container = IocConfig.GetConfiguredContainer();

        private Func<HttpContext, bool> EndpointTraversalSupplier() => context
            => _container.Resolve<EndpointTraversalInspection>()
                .InspectionIsCompliant(
                    context,
                    _container.Resolve<IAppState>().GetActiveInspectionSettings().EndpointTraversalSettings
                );

        public List<Func<HttpContext, bool>> PanRequestMethodInspectionTypes() =>
        [
            GeoRestrictionSupplier(),
            EndpointTraversalSupplier(),
            PortDiscoverySupplier(),
        ];

        private Func<HttpContext, bool> PortDiscoverySupplier() => context
            => _container.Resolve<PortDiscoveryInspection>()
                .InspectionIsCompliant(
                    context,
                    _container.Resolve<IAppState>().GetActiveInspectionSettings().PortDiscoverySettings
                    );

        private Func<HttpContext, bool> GeoRestrictionSupplier() => context
            => _container.Resolve<GeoBlockingInspection>()
                .InspectionIsCompliant(
                    context,
                    _container.Resolve<IAppState>().GetActiveInspectionSettings().GeoBlockingSettings
                    );

        public List<Func<HttpContext, bool>> GetRequestMethodInspectionTypes() =>
        [
        ];

        public List<Func<HttpContext, bool>> PostRequestMethodInspectionTypes() =>
        [
        ];

        public List<Func<HttpContext, bool>> PutRequestMethodInspectionTypes() =>
        [
        ];

        public List<Func<HttpContext, bool>> DeleteRequestMethodInspectionTypes() =>
        [
        ];
    }
}