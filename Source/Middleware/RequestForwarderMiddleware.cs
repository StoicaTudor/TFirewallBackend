using TFirewall.Source.RequestForwarding;
using TFirewall.Source.SystemConfig;
using Unity;

namespace TFirewall.Source.Middleware;

public class RequestForwarderMiddleware(RequestDelegate next)
{
    private readonly IUnityContainer _container = IocConfig.GetConfiguredContainer();

    public async Task InvokeAsync(HttpContext context)
    {
        // await _container.Resolve<IRequestForwarder>().ForwardRequest(context);
        await next(context);
        
        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsync("Request accepted by firewall.");
    }
}