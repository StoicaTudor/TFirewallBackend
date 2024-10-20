namespace TFirewall.Source.Dtos.User;

public record UserProfileUpdateResponseDto(
    string Id,
    string UserId,
    string Content,
    string Name,
    bool IsActiveProfile
);