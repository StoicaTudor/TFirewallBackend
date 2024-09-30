namespace TFirewall.Source.UserAppConfig.Entities;

public class FirewallLog
{
    public required string Id { get; set; }
    public required UserProfile UserProfile { get; set; }
    public required DateTime Timestamp { get; set; }
    public required LogSeverity Severity { get; set; }
    public required string Content { get; set; }
}