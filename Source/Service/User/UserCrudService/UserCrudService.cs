using System.Text.Json;
using TFirewall.Source.FirewallCore.Services;
using TFirewall.Source.FirewallCore.Settings;
using TFirewall.Source.Persistence.UserRepository;
using TFirewall.Source.Service.FirewallLog.LogCrudService;
using TFirewall.Source.UserAppConfig.AppState;
using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Service.User.UserCrudService;

public class UserCrudService(
    IUserRepository userRepository,
    ILogCrudService logCrudService,
    IJsonValidator jsonValidator,
    IAppState appState) : IUserCrudService
{
    public async Task<UserProfile> CreateUserProfile(UserProfile userProfile)
    {
        if (userProfile.IsActiveProfile)
            userRepository.SetAllUserProfilesToInactive();

        await userRepository.CreateUserProfile(userProfile);
        return userProfile;
    }

    public async Task<UserProfile> UpdateUserProfile(UserProfile userProfile)
    {
        if (userProfile.IsActiveProfile)
        {
            userRepository.SetAllUserProfilesToInactive();
            
            CompositeInspectionSettings? settings = jsonValidator.IsValid(userProfile.Content)
                ? JsonSerializer.Deserialize<CompositeInspectionSettings>(userProfile.Content)
                : null;

            UserAppConfig.Entities.FirewallLog firewallLog = settings == null
                ? new UserAppConfig.Entities.FirewallLog
                {
                    Id = Guid.NewGuid().ToString(),
                    UserProfile = userProfile,
                    Timestamp = DateTime.UtcNow,
                    Severity = LogSeverity.Warning,
                    Message =
                        $"Active Profile was supposed to be changed, but the content is invalid - {userProfile.Name} - {userProfile.Content}."
                }
                : new UserAppConfig.Entities.FirewallLog
                {
                    Id = Guid.NewGuid().ToString(),
                    UserProfile = userProfile,
                    Timestamp = DateTime.UtcNow,
                    Severity = LogSeverity.Info,
                    Message = $"Active Profile has been changed - {userProfile.Name} - {userProfile.Content}."
                };
            await logCrudService.CreateLog(firewallLog);

            if (settings != null)
                appState.SetActiveInspectionSettings(settings);
        }

        await userRepository.UpdateUserProfileAsync(userProfile);
        return userProfile;
    }

    public async Task DeleteUserProfileAsync(string profileId)
    {
        await userRepository.DeleteUserProfileAsync(profileId);
    }

    public async Task CreateUser(UserAppConfig.Entities.User user)
    {
        await userRepository.CreateUser(user);
        return;
    }

    public async Task<IEnumerable<UserAppConfig.Entities.User>> GetAllUsersAsync()
    {
        return await userRepository.GetAllUsers();
    }

    public async Task DeleteAllUsers()
    {
        await userRepository.DeleteAllUser();
    }

    public Task<UserProfile> GetUserProfile(string userProfileId)
    {
        throw new NotImplementedException();
    }

    public async Task<UserProfile> GetActiveUserProfileAsync()
    {
        return await userRepository.GetActiveUserProfileAsync();
    }
}