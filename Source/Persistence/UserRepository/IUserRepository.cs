using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Persistence.UserRepository;

public interface IUserRepository
{
    Task CreateUserProfile(UserProfile userProfile);
    Task UpdateUserProfileAsync(UserProfile userProfile);
    Task CreateUser(User user);
    Task DeleteAllUser();
    Task<UserProfile> GetActiveUserProfileAsync();
    Task<IEnumerable<User>> GetAllUsers();
    void SetAllUserProfilesToInactive();
    Task DeleteUserProfileAsync(string profileId);
}