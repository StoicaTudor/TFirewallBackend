using FluentMigrator;

namespace TFirewall.Source.SystemConfig.DatabaseAndMigrations.Migrations;

[Migration(202409091532)]
public class CreateUsersTable : Migration
{
    public override void Up()
    {
        Create.Table(TablesAccessors.UsersTable.TableName)
            .WithColumn(TablesAccessors.UsersTable.Id).AsString().PrimaryKey()
            .WithColumn(TablesAccessors.UsersTable.Email).AsString().NotNullable()
            .WithColumn(TablesAccessors.UsersTable.Password).AsString().NotNullable()
            .WithColumn(TablesAccessors.UsersTable.Role).AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table(TablesAccessors.UsersTable.TableName);
    }
}