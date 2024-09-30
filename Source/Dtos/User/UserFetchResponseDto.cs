namespace TFirewall.Source.Dtos.User;

public record UserFetchResponseDto(string Email, string Role)
{
    public static UserFetchResponseDto FromUser(UserAppConfig.Entities.User user) =>
        new(
            Email: user.Email,
            Role: user.Role.ToString()
        );
}