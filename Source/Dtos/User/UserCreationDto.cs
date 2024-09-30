namespace TFirewall.Source.Dtos.User;

public record UserCreationDto(
    string Email,
    string Password,
    string Role
);