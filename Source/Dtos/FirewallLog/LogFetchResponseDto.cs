namespace TFirewall.Source.Dtos.FirewallLog;

public record LogFetchResponseDto(
    string Timestamp,
    string Severity,
    string Message
);