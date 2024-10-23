namespace TFirewall.Source.Middleware;

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class PutRequestInspectorMiddleware
{
    public bool RequestPasses(HttpContext context) => IsNotMalicious(context.Request);


    private bool IsMalicious(HttpRequest request)
    {
        // Add your inspection logic here
        return false; // Example placeholder
    }
    
    private bool IsNotMalicious(HttpRequest request) => !IsMalicious(request);
}
