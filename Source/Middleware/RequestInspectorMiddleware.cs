using TFirewall.Source.SystemConfig;
using Unity;

namespace TFirewall.Source.Middleware;

public class RequestInspectorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly PostRequestInspectorMiddleware _postMiddleware;
    private readonly PutRequestInspectorMiddleware _putMiddleware;
    private readonly GetRequestInspectorMiddleware _getMiddleware;
    private readonly DeleteRequestInspectorMiddleware _deleteMiddleware;

    public RequestInspectorMiddleware(RequestDelegate next)
    {
        _next = next;

        IUnityContainer container = IocConfig.GetConfiguredContainer();
        _postMiddleware = container.Resolve<PostRequestInspectorMiddleware>();
        _putMiddleware = container.Resolve<PutRequestInspectorMiddleware>();
        _getMiddleware = container.Resolve<GetRequestInspectorMiddleware>();
        _deleteMiddleware = container.Resolve<DeleteRequestInspectorMiddleware>();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (RequestPasses(context))
            await _next(context);
    }

    private bool RequestPasses(HttpContext context) =>
        context.Request.Method switch
        {
            Constants.Post => _postMiddleware.RequestPasses(context),
            Constants.Get => _getMiddleware.RequestPasses(context),
            Constants.Put => _putMiddleware.RequestPasses(context),
            Constants.Delete => _deleteMiddleware.RequestPasses(context),
            _ => false
        };
}