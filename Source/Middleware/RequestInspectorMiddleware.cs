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
        if (!RequestPasses(context))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync(GetDummyResponse());
            await Task.Delay(5000);
            return;
        }

        await _next(context);
    }

    private bool RequestPasses(HttpContext context) =>
        context.Request.Method switch
        {
            Constants.Post => _postMiddleware.RequestPasses(context),
            Constants.Get => _getMiddleware.RequestPasses(context),
            Constants.Put => _putMiddleware.RequestPasses(context),
            Constants.Delete => _deleteMiddleware.RequestPasses(context),
            Constants.Options => true,
            _ => false
        };

    private string GetDummyResponse() =>
        """
        {
          "user": {
            "id": "12345",
            "firstName": "John",
            "lastName": "Doe",
            "email": "john.doe@example.com",
            "phone": "+1-555-123-4567",
            "address": {
              "street": "123 Elm St",
              "city": "Springfield",
              "state": "IL",
              "postalCode": "62701",
              "country": "USA"
            },
            "dateOfBirth": "1990-01-01",
            "gender": "male",
            "occupation": "Software Developer",
            "socialSecurityNumber": "123-45-6789",
            "creditCard": {
              "cardNumber": "4111-1111-1111-1111",
              "expirationDate": "12/25",
              "cvv": "123",
              "cardHolderName": "John Doe"
            },
            "bankAccount": {
              "accountNumber": "123456789",
              "routingNumber": "987654321",
              "bankName": "Example Bank",
              "accountType": "Checking"
            }
          },
          "status": "success",
          "message": "Fake personal data generated successfully."
        }
        """;
}