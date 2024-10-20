using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TFirewall.Source.Dtos.FirewallLog;
using TFirewall.Source.Dtos.User;
using TFirewall.Source.Service.FirewallLog.LogCrudService;
using TFirewall.Source.Service.User.UserCrudService;
using TFirewall.Source.SystemConfig;
using TFirewall.Source.UserAppConfig.Entities;
using Unity;

namespace TFirewall.Source.Api;

[Route(ApiConstants.LogsApiConstants.Root)]
[ApiController]
public class LogsApi : ControllerBase
{
    private readonly ILogCrudService _logCrudService;
    private readonly IMapper _mapper;

    public LogsApi()
    {
        IUnityContainer container = IocConfig.GetConfiguredContainer();
        _logCrudService = container.Resolve<ILogCrudService>();
        _mapper = container.Resolve<IMapper>();
    }

    [HttpGet(ApiConstants.LogsApiConstants.GetAllLogs)]
    public async Task<IActionResult> GetAllLogs() =>
        Ok(_mapper.Map<IEnumerable<LogFetchResponseDto>>(await _logCrudService.GetAllLogsAsync()));
}