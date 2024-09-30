using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Service.User.UserCrudService;

public interface IUserCrudService
{
    Task CreateUserProfile(UserProfile userProfile);
    Task CreateUser(UserAppConfig.Entities.User dto);
    Task DeleteAllUsers();
    Task<IEnumerable<UserAppConfig.Entities.User>> GetAllUsers();
}