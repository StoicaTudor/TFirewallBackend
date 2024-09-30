using Microsoft.AspNetCore.Mvc;
using TFirewall.Source.Middleware;
using Unity;

namespace TFirewall.Source.Api;

// [EnableCors("CorsPolicy")]
[Route("firewall")]
[ApiController]
public class FirewallApi
{
    public FirewallApi()
    {
        // IUnityContainer container = IocConfig.GetConfiguredContainer();
        // _computerService = container.Resolve<IComputerService>();
    }
}