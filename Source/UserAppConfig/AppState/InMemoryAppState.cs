using System.Text.Json;
using TFirewall.Source.FirewallCore.Services;
using TFirewall.Source.FirewallCore.Settings;
using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.UserAppConfig.AppState;

public class InMemoryAppState(IJsonValidator jsonValidator) : IAppState
{
    private UserProfile _activeUserProfile = new()
    {
        Id = "",
        UserId = "",
        Content = "",
        Name = "",
        IsActiveProfile = false
    };

    private CompositeInspectionSettings _compositeInspection = new();

    public UserProfile GetActiveUserProfile() => _activeUserProfile;
    public CompositeInspectionSettings GetActiveInspectionSettings() => _compositeInspection;
    public void SetActiveInspectionSettings(CompositeInspectionSettings settings) => _compositeInspection = settings;

    public void SetActiveUserProfile(UserProfile userProfile)
    {
        _activeUserProfile = userProfile;
        SetActiveInspectionSettings(
            jsonValidator.IsValid(userProfile.Content)
                ? JsonSerializer.Deserialize<CompositeInspectionSettings>(userProfile.Content) ?? new()
                : new()
        );
    }
}