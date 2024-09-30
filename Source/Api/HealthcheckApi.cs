using Microsoft.AspNetCore.Mvc;

namespace TFirewall.Source.Api;

[Route(ApiConstants.HealthcheckApiConstants.Root)]
[ApiController]
public class HealthcheckApi : Controller
{
    [HttpGet(ApiConstants.HealthcheckApiConstants.IsUp)]
    public IActionResult IsUp() => Ok("{message: healthcheck OK}");
}