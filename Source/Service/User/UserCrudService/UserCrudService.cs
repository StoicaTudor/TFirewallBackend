using TFirewall.Source.Persistence.UserRepository;
using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Service.User.UserCrudService;

public class UserCrudService(IUserRepository userRepository) : IUserCrudService
{
    public async Task CreateUserProfile(UserProfile userProfile)
    {
        await userRepository.CreateUserProfile(userProfile);
    }

    public async Task CreateUser(UserAppConfig.Entities.User user)
    {
        await userRepository.CreateUser(user);
    }

    public async Task<IEnumerable<UserAppConfig.Entities.User>> GetAllUsers()
    {
        return await userRepository.GetAllUsers();
    }

    public async Task DeleteAllUsers()
    {
        await userRepository.DeleteAllUser();
    }
}