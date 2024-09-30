using Microsoft.Extensions.Primitives;

namespace TFirewall.Source.RequestForwarding;

public class RequestForwarder(HttpClient httpClient) : IRequestForwarder
{
    public async Task ForwardRequest(HttpContext context)
    {
        // Step 2: Forward request to the target server
        string targetUrl = $"https://targetserver.com{context.Request.Path}{context.Request.QueryString}";

        // Create an HttpRequestMessage based on the incoming HttpContext
        HttpRequestMessage requestMessage = new HttpRequestMessage
        {
            Method = new HttpMethod(context.Request.Method),
            RequestUri = new Uri(targetUrl),
            Content = await GetContentFromRequest(context)
        };

        // Forward headers
        foreach (KeyValuePair<string, StringValues> header in context.Request.Headers)
        {
            if (!requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray()))
            {
                requestMessage.Content?.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
            }
        }

        // Step 3: Forward the request to the target server
        HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

        // Step 4: Relay the response from the target server back to the client
        context.Response.StatusCode = (int)responseMessage.StatusCode;

        foreach (KeyValuePair<string, IEnumerable<string>> header in responseMessage.Headers)
        {
            context.Response.Headers[header.Key] = header.Value.ToArray();
        }

        foreach (KeyValuePair<string, IEnumerable<string>> header in responseMessage.Content.Headers)
        {
            context.Response.Headers[header.Key] = header.Value.ToArray();
        }

        await responseMessage.Content.CopyToAsync(context.Response.Body);
    }

    private static Task<HttpContent> GetContentFromRequest(HttpContext context)
    {
        if (context.Request.ContentLength == null || context.Request.ContentLength == 0)
            return Task.FromResult<HttpContent>(null);

        StreamContent streamContent = new StreamContent(context.Request.Body);
        foreach (KeyValuePair<string, StringValues> header in context.Request.Headers)
        {
            streamContent.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
        }

        return Task.FromResult<HttpContent>(streamContent);
    }
}