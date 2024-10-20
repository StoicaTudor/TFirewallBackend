using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Service.User.UserCrudService;

public interface IUserCrudService
{
    Task<UserProfile> CreateUserProfile(UserProfile userProfile);
    Task<UserProfile> UpdateUserProfile(UserProfile userProfile);
    Task DeleteUserProfileAsync(string profileId);
    Task<UserProfile> GetUserProfile(string userProfileId);
    Task CreateUser(UserAppConfig.Entities.User dto);
    Task DeleteAllUsers();
    Task<IEnumerable<UserAppConfig.Entities.User>> GetAllUsersAsync();
}