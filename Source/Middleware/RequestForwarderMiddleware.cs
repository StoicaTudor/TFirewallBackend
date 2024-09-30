using TFirewall.Source.RequestForwarding;
using TFirewall.Source.SystemConfig;
using Unity;

namespace TFirewall.Source.Middleware;

public class RequestForwarderMiddleware
{
    private readonly IRequestForwarder _requestForwarder;

    public RequestForwarderMiddleware()
    {
        IUnityContainer container = IocConfig.GetConfiguredContainer();
        _requestForwarder = container.Resolve<IRequestForwarder>();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _requestForwarder.ForwardRequest(context);
    }
}