namespace TFirewall.Source.UserAppConfig.Entities;

public class User
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public UserRole Role { get; set; }
    public List<UserProfile> Profiles { get; set; } = [];
}