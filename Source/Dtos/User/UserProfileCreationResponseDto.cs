namespace TFirewall.Source.Dtos.User;

public record UserProfileCreationResponseDto(
    string Id,
    string UserId,
    string Content,
    string Name,
    bool IsActiveProfile
);