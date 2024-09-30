using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Persistence.UserRepository;

public interface IUserRepository
{
    Task CreateUserProfile(UserProfile userProfile);
    Task CreateUser(User user);
    Task DeleteAllUser();
    Task<IEnumerable<User>> GetAllUsers();
}