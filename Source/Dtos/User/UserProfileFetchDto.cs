using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Dtos.User;

public record UserProfileFetchDto(
    string Id,
    string UserId,
    string Content,
    bool IsActiveProfile,
    string Name
)
{
    public static UserProfileFetchDto FromUserProfile(UserProfile userProfile) =>
        new(
            Id: userProfile.Id,
            UserId: userProfile.UserId,
            Name: userProfile.Name,
            IsActiveProfile: userProfile.IsActiveProfile,
            Content: userProfile.Content
        );
}