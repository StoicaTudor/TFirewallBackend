using AutoMapper;
using TFirewall.Source.FirewallCore.Inspections;
using TFirewall.Source.FirewallCore.Inspections.PanMethodInspections.EndpointTraversal;
using TFirewall.Source.FirewallCore.Inspections.PanMethodInspections.GeoBlocking;
using TFirewall.Source.FirewallCore.Inspections.PanMethodInspections.PortDiscovery;
using TFirewall.Source.FirewallCore.Settings;
using TFirewall.Source.Mappers.User;
using TFirewall.Source.Middleware;
using TFirewall.Source.Persistence;
using TFirewall.Source.Persistence.LogsRepository;
using TFirewall.Source.Persistence.UserRepository;
using TFirewall.Source.RequestForwarding;
using TFirewall.Source.Service.FirewallLog.LogCrudService;
using TFirewall.Source.Service.User.UserCrudService;
using Unity;
using Unity.Injection;

namespace TFirewall.Source.SystemConfig;

public static class IocConfig
{
    private static readonly IUnityContainer Container = new UnityContainer();

    public static void RegisterComponents(ConfigurationManager configuration)
    {
        Container.RegisterInstance<IConfiguration>(configuration);
        RegisterServices();
        RegisterDatabaseContext();
        RegisterMiddleware();
        RegisterRepositories();
        RegisterInspectionServices();
        RegisterMappers();
    }

    private static void RegisterDatabaseContext()
    {
        Container.RegisterSingleton(typeof(DbContext));
    }

    private static void RegisterMappers()
    {
        Container.RegisterType<IMapper, Mapper>(
            new InjectionConstructor(new MapperConfiguration(cfg => { cfg.AddProfile(new UserMapProfile()); }))
        );
    }

    private static void RegisterRepositories()
    {
        Container.RegisterType<IUserRepository, UserRepository>();
        Container.RegisterType<ILogsRepository, LogsRepository>();
    }

    private static void RegisterServices()
    {
        Container.RegisterType<IRequestForwarder, RequestForwarder>();
        Container.RegisterType<IUserCrudService, UserCrudService>();
        Container.RegisterType<ILogCrudService, LogCrudService>();
    }

    private static void RegisterMiddleware()
    {
        Container.RegisterSingleton(typeof(GetRequestInspectorMiddleware));
        Container.RegisterSingleton(typeof(PostRequestInspectorMiddleware));
        Container.RegisterSingleton(typeof(PutRequestInspectorMiddleware));
        Container.RegisterSingleton(typeof(DeleteRequestInspectorMiddleware));
        Container.RegisterSingleton(typeof(RequestInspectorMiddleware));
    }

    private static void RegisterInspectionServices()
    {
        Container.RegisterSingleton(typeof(InspectionsManager));

        // pan-method inspections
        Container.RegisterType<IInspection<EndpointTraversalInspectionSettings>, EndpointTraversalInspection>();
        Container.RegisterType<IInspection<PortDiscoveryInspectionSettings>, PortDiscoveryInspection>();
        Container.RegisterType<IInspection<GeoBlockingInspectionSettings>, GeoBlockingInspection>();

        // GET-specific-method inspections

        // POST-specific-method inspections

        // PUT-specific-method inspections

        // DELETE-specific-method inspections
    }

    // Eventual, throw exception if container is not configured, but keep it simple currently.
    public static IUnityContainer GetConfiguredContainer() => Container;
}