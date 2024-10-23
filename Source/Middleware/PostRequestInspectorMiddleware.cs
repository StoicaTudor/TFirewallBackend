namespace TFirewall.Source.Middleware;

public class PostRequestInspectorMiddleware
{
    public bool RequestPasses(HttpContext context) => IsNotMalicious(context.Request);
    
    private bool IsMalicious(HttpRequest request)
    {
        // Add your inspection logic here
        return false; // Example placeholder
    }

    private bool IsNotMalicious(HttpRequest request) => !IsMalicious(request);
}
