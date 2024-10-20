namespace TFirewall.Source.Dtos.User;

public record UserProfileEditDto(
    bool IsActiveProfile,
    string Name,
    string Id,
    string Content,
    string UserId
);