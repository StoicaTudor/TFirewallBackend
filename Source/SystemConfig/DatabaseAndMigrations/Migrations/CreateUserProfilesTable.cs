using FluentMigrator;

namespace TFirewall.Source.SystemConfig.DatabaseAndMigrations.Migrations;

[Migration(202409091533)]
public class CreateUserProfilesTable : Migration
{
    public override void Up()
    {
        Create.Table(TablesAccessors.UsersProfilesTable.TableName)
            .WithColumn(TablesAccessors.UsersProfilesTable.Id).AsString().PrimaryKey()
            .WithColumn(TablesAccessors.UsersProfilesTable.UserId).AsString().ForeignKey()
            .WithColumn(TablesAccessors.UsersProfilesTable.Content).AsCustom("TEXT").NotNullable()
            .WithColumn(TablesAccessors.UsersProfilesTable.IsActiveProfile).AsBoolean().NotNullable();
        
        Create.ForeignKey(TablesAccessors.ForeignKeys.UsersToUsersProfilesForeignKey)
            .FromTable(TablesAccessors.UsersProfilesTable.TableName)
            .ForeignColumn(TablesAccessors.UsersProfilesTable.UserId)
            .ToTable(TablesAccessors.UsersTable.TableName)
            .PrimaryColumn(TablesAccessors.UsersTable.Id);
    }

    public override void Down()
    {
        Delete.ForeignKey(TablesAccessors.ForeignKeys.UsersToUsersProfilesForeignKey)
            .OnTable(TablesAccessors.UsersProfilesTable.TableName);
        Delete.Table(TablesAccessors.UsersProfilesTable.TableName);
    }
}