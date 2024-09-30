namespace TFirewall.Source.Dtos.User;

public record UserProfileCreationDto(
    string Name,
    string UserId,
    string Content
);