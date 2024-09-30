using FluentMigrator;

namespace TFirewall.Source.SystemConfig.DatabaseAndMigrations.Migrations;

[Migration(202430091532)]
public class CreateLogsTable : Migration
{
    public override void Up()
    {
        Create.Table(TablesAccessors.LogsTable.TableName)
            .WithColumn(TablesAccessors.LogsTable.Id).AsString().PrimaryKey()
            .WithColumn(TablesAccessors.LogsTable.UserProfileId).AsString().ForeignKey()
            .WithColumn(TablesAccessors.LogsTable.Severity).AsInt32().NotNullable()
            .WithColumn(TablesAccessors.LogsTable.Message).AsString().NotNullable()
            .WithColumn(TablesAccessors.LogsTable.Timestamp).AsString().NotNullable();
        
        Create.ForeignKey(TablesAccessors.ForeignKeys.LogsToUsersProfilesForeignKey)
            .FromTable(TablesAccessors.LogsTable.TableName)
            .ForeignColumn(TablesAccessors.LogsTable.UserProfileId)
            .ToTable(TablesAccessors.UsersProfilesTable.TableName)
            .PrimaryColumn(TablesAccessors.UsersProfilesTable.Id);
    }

    public override void Down()
    {
        Delete.Table(TablesAccessors.LogsTable.TableName);
    }
}