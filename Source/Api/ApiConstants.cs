namespace TFirewall.Source.Api;

public static class ApiConstants
{
    public class UserApiConstants
    {
        public const string Root = "users";
        public const string CreateUserProfile = "create-profile";
        public const string UpdateUserProfile = "update-profile";
        public const string DeleteUserProfile = "delete-profile/{profileId}";
        public const string SetActiveUserProfile = "active-profile";
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
    
    public class JsonApiConstants
    {
        public const string Root = "json";
        public const string ValidateJson = "validate-json";
        public const string LoadUserProfileSettings = "load-user-profile-settings";
    }
    
    public class HealthcheckApiConstants
    {
        public const string Root = "healthcheck";
        public const string IsUp = "is-up";
    }
}