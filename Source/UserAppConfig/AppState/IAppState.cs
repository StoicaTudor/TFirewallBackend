using TFirewall.Source.FirewallCore.Settings;
using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.UserAppConfig.AppState;

public interface IAppState
{
    void SetActiveInspectionSettings(CompositeInspectionSettings settings);
    CompositeInspectionSettings GetActiveInspectionSettings();
    UserProfile GetActiveUserProfile();
    void SetActiveUserProfile(UserProfile userProfile);
}