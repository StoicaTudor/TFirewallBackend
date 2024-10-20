using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Service.FirewallLog.LogCrudService;

public interface ILogCrudService
{
    Task CreateLog(UserAppConfig.Entities.FirewallLog firewallLog);
    Task<IEnumerable<UserAppConfig.Entities.FirewallLog>> GetAllLogsOfUserProfile(UserProfile userProfile);
    Task<IEnumerable<UserAppConfig.Entities.FirewallLog>> GetAllLogsAsync();
}