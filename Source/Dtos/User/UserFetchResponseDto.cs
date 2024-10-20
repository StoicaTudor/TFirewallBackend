namespace TFirewall.Source.Dtos.User;

public record UserFetchResponseDto(string Id, string Email, string Role, IEnumerable<UserProfileFetchDto> UserProfiles)
{
    public static UserFetchResponseDto FromUser(UserAppConfig.Entities.User user) =>
        new(
            Id: user.Id,
            Email: user.Email,
            Role: user.Role.ToString(),
            UserProfiles: user.Profiles.Select(UserProfileFetchDto.FromUserProfile)
        );
}