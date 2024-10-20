namespace TFirewall.Source.UserAppConfig.Entities;

public class UserProfile
{
    public required string Id { get; set; }
    public required string UserId { get; set; }
    public required string Content { get; set; }
    public required string Name { get; set; }
    public required bool IsActiveProfile { get; set; }
}