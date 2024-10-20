using AutoMapper;
using TFirewall.Source.Dtos.FirewallLog;
using TFirewall.Source.Dtos.User;
using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Mappers;

public class LogsMapProfile : Profile
{
    public LogsMapProfile()
    {
        CreateMap<FirewallLog, LogFetchResponseDto>();
    }
}