namespace TFirewall.Source.RequestForwarding;

public interface IRequestForwarder
{
    Task ForwardRequest(HttpContext context);
}