using TFirewall.Source.FirewallCore.Settings;
using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.UserAppConfig.AppState;

// TODO: pls implement
public class RedisAppState : IAppState
{
    private UserProfile _activeUserProfile = new()
    {
        Id = "",
        UserId = "",
        Content = "",
        Name = "",
        IsActiveProfile = false
    };

    public void SetActiveInspectionSettings(CompositeInspectionSettings settings)
    {
        throw new NotImplementedException();
    }

    public CompositeInspectionSettings GetActiveInspectionSettings()
    {
        throw new NotImplementedException();
    }

    public UserProfile GetActiveUserProfile() => _activeUserProfile;

    public void SetActiveUserProfile(UserProfile userProfile)
    {
        _activeUserProfile = userProfile;
    }
}