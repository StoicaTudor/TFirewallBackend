namespace TFirewall.Source.Api;

public static class ApiConstants
{
    public class UserApiConstants
    {
        public const string Root = "users";
        public const string CreateUserProfile = "create-profile";
        public const string CreateUser = "create";
        public const string DeleteAllUsers = "delete-all";
        public const string GetAllUsers = "all";
    }
    
    public class LogsApiConstants
    {
        public const string Root = "logs";
        public const string CreateLog = "create";
        public const string GetAllLogs = "all";
    }
    
    public class HealthcheckApiConstants
    {
        public const string Root = "healthcheck";
        public const string IsUp = "is-up";
    }
}