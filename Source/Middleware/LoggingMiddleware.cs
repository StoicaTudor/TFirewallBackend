using System.Diagnostics;

namespace TFirewall.Source.Middleware;

public class LoggingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        // FirewallLog the request
        var stopwatch = Stopwatch.StartNew();
        Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");

        // Call the next middleware in the pipeline
        await next(context);

        // FirewallLog the response
        stopwatch.Stop();
        Console.WriteLine($"Outgoing Response: {context.Response.StatusCode} (Processing Time: {stopwatch.ElapsedMilliseconds} ms)");
    }
}