using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Persistence.LogsRepository;

public interface ILogsRepository
{
    Task CreateLog(FirewallLog firewallLog);
    Task<IEnumerable<FirewallLog>> GetAllLogsOfUserProfile(UserProfile userProfile);
    Task<IEnumerable<FirewallLog>> GetAllLogsAsync();
}