using System.Data;
using System.Data.Common;
using FluentMigrator.Infrastructure;
using FluentMigrator.Runner;
using Microsoft.IdentityModel.Tokens;
using TFirewall.Source.Persistence;
using Unity;

namespace TFirewall.Source.SystemConfig.DatabaseAndMigrations;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host, ILogger logger)
    {
        using IServiceScope scope = host.Services.CreateScope();
        IMigrationRunner migrationRunner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        try
        {
            HashSet<long> appliedMigrations = GetAppliedMigrations();
            if (appliedMigrations.IsNullOrEmpty())
                migrationRunner.MigrateUp();
            else SequentiallyApplyMigrations(migrationRunner, appliedMigrations);
        }
        catch (DbException exception)
        {
            logger.LogCritical(exception, "Failed to perform migration.");
            throw;
        }

        return host;
    }

    private static void SequentiallyApplyMigrations(IMigrationRunner migrationRunner, HashSet<long> appliedMigrations)
    {
        // List all available migrations
        SortedList<long, IMigrationInfo>? migrations = migrationRunner.MigrationLoader.LoadMigrations();
        foreach (KeyValuePair<long, IMigrationInfo> migration in
                 migrations.Where(migration
                     => !appliedMigrations.Contains(migration.Key)))
            migrationRunner.MigrateUp(migration.Key);
    }

    private static HashSet<long> GetAppliedMigrations()
    {
        IUnityContainer unityContainer = IocConfig.GetConfiguredContainer();
        DbContext dbContext = unityContainer.Resolve<DbContext>();

        HashSet<long> appliedMigrations = [];

        using IDbConnection connection = dbContext.CreateConnection();
        connection.Open();

        // Check if the VersionInfo table exists
        IDbCommand checkTableCommand = connection.CreateCommand();
        checkTableCommand.CommandText = $"""
                                         
                                                 SELECT COUNT(*)
                                                 FROM INFORMATION_SCHEMA.TABLES
                                                 WHERE TABLE_NAME = 'VersionInfo'
                                         """;

        bool tableExists = (long)(checkTableCommand.ExecuteScalar() ?? 0) > 0;
        if (!tableExists)
            return appliedMigrations;

        // If the table exists, query for the applied migrations
        IDbCommand command = connection.CreateCommand();
        command.CommandText = "SELECT Version FROM VersionInfo WHERE AppliedOn IS NOT NULL";

        using IDataReader reader = command.ExecuteReader();
        while (reader.Read())
            appliedMigrations.Add(reader.GetInt64(0)); // Version column is of type long

        return appliedMigrations;
    }
}