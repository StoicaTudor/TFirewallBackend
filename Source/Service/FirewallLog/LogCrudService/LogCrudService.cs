using TFirewall.Source.Persistence.LogsRepository;
using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Service.FirewallLog.LogCrudService;

public class LogCrudService(ILogsRepository logRepository) : ILogCrudService
{
    public async Task CreateLog(UserAppConfig.Entities.FirewallLog log)
    {
        await logRepository.CreateLog(log);
    }

    public async Task<IEnumerable<UserAppConfig.Entities.FirewallLog>> GetAllLogsOfUserProfile(UserProfile userProfile)
    {
        return await logRepository.GetAllLogsOfUserProfile(userProfile);
    }

    public async Task<IEnumerable<UserAppConfig.Entities.FirewallLog>> GetAllLogsAsync()
    {
        return await logRepository.GetAllLogsAsync();
    }
}