using System.Data;
using Dapper;
using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Persistence.LogsRepository;

public class LogsRepository(DbContext dbContext) : ILogsRepository
{
    public async Task CreateLog(FirewallLog firewallLog)
    {
        using IDbConnection connection = dbContext.CreateConnection();

        const string query = """
                                         INSERT INTO FirewallLogs (Id, UserProfileID, Timestamp, Severity)
                                         VALUES (@Id, @UserProfileID, @Timestamp, @Severity);
                             """;

        var parameters = new { Id = Guid.NewGuid(), UserProfileID = firewallLog.UserProfile.Id, DateTime.Now, LogSeverity = firewallLog.Severity };
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task<IEnumerable<FirewallLog>> GetAllLogsOfUserProfile(UserProfile userProfile)
    {
        using IDbConnection connection = dbContext.CreateConnection();
        const string query = "SELECT * FROM FirewallLogs"; // where UserProfile

        return await connection.QueryAsync<FirewallLog>(query);
    }

    public async Task<IEnumerable<FirewallLog>> GetAllLogs()
    {
        using IDbConnection connection = dbContext.CreateConnection();
        const string query = "SELECT * FROM FirewallLogs";

        return await connection.QueryAsync<FirewallLog>(query);
    }
}