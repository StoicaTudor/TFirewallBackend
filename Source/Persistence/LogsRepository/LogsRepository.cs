using System.Data;
using System.Globalization;
using Dapper;
using FluentValidation;
using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Persistence.LogsRepository;

public class LogsRepository(DbContext dbContext) : ILogsRepository
{
    public async Task CreateLog(FirewallLog firewallLog)
    {
        using IDbConnection connection = dbContext.CreateConnection();

        const string query = """
                                         INSERT INTO FirewallLogs (Id, UserProfileID, Timestamp, Severity, Message)
                                         VALUES (@Id, @UserProfileID, @Timestamp, @Severity, @Message);
                             """;

        var parameters = new
        {
            Id = Guid.NewGuid(),
            UserProfileID = firewallLog.UserProfile.Id,
            Timestamp = DateTime.UtcNow.ToString("o"),
            Severity = firewallLog.Severity,
            Message = firewallLog.Message
        };
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task<IEnumerable<FirewallLog>> GetAllLogsOfUserProfile(UserProfile userProfile)
    {
        using IDbConnection connection = dbContext.CreateConnection();
        const string query = "SELECT * FROM FirewallLogs";

        IEnumerable<FirewallLogHelper> logs = await connection.QueryAsync<FirewallLogHelper>(query);
        return logs.Select(helper => helper.ToEntityObject());
    }

    public async Task<IEnumerable<FirewallLog>> GetAllLogsAsync()
    {
        using IDbConnection connection = dbContext.CreateConnection();
        const string query = "SELECT * FROM FirewallLogs ";

        IEnumerable<FirewallLogHelper> logs = await connection.QueryAsync<FirewallLogHelper>(query);
        return logs.Select(helper => helper.ToEntityObject());
    }

    private class FirewallLogHelper
    {
        public required string Id { get; set; }
        public required UserProfile UserProfile { get; set; }
        public required string Timestamp { get; set; }
        public required LogSeverity Severity { get; set; }
        public required string Message { get; set; }

        public FirewallLog ToEntityObject() => new()
        {
            Id = Id,
            Message = Message,
            Severity = Severity,
            Timestamp = DateTime.UtcNow,
            UserProfile = UserProfile
        };
    }
}