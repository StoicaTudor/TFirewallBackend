namespace TFirewall.Source.SystemConfig.DatabaseAndMigrations.Migrations;

public class TablesAccessors
{
    private static readonly string Id = "Id";
    private static readonly string Email = "Email";
    private static readonly string Password = "Password";

    public class ForeignKeys
    {
        public static readonly string UsersToUsersProfilesForeignKey = "FK_UserProfiles_Users";
        public static readonly string LogsToUsersProfilesForeignKey = "FK_Logs_UserProfiles";
    }
    
    public class UsersTable
    {
        public static readonly string TableName = "Users";
        public static readonly string Id = TablesAccessors.Id;
        public static readonly string Email = TablesAccessors.Email;
        public static readonly string Password = TablesAccessors.Password;
        public static readonly string Role = "Role";
    }
    
    public class LogsTable
    {
        public static readonly string TableName = "FirewallLogs";
        public static readonly string Id = TablesAccessors.Id;
        public static readonly string UserProfileId = "UserProfileId";
        public static readonly string Timestamp = "Timestamp";
        public static readonly string Severity = "Severity";
        public static readonly string Message = "Message";
    }

    public class UsersProfilesTable
    {
        public static readonly string TableName = "UserProfiles";
        public static readonly string Id = TablesAccessors.Id;
        public static readonly string UserId = "UserId";
        public static readonly string Content = "Content";
    }
}