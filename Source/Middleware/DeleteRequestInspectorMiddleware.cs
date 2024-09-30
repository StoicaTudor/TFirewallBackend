﻿namespace TFirewall.Source.Middleware;

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class DeleteRequestInspectorMiddleware
{
    public bool RequestPasses(HttpContext context) => IsMalicious(context.Request);


    private bool IsMalicious(HttpRequest request)
    {
        // Add your inspection logic here
        return false; // Example placeholder
    }
}