using System.Data;
using Dapper;
using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Persistence.UserRepository;

public class UserRepository(DbContext dbContext) : IUserRepository
{
    public async Task CreateUserProfile(UserProfile userProfile)
    {
        using IDbConnection connection = dbContext.CreateConnection();

        const string query = """
                                         INSERT INTO UserProfiles (Id, UserId, Content)
                                         VALUES (@Id, @UserId, @Content);
                             """;

        var parameters = (Id: Guid.NewGuid(), Content: userProfile.Content);

        await connection.ExecuteAsync(query, parameters);
    }

    public async Task CreateUser(User user)
    {
        using IDbConnection connection = dbContext.CreateConnection();

        const string query = """
                             
                                         INSERT INTO Users (Id, Email, Password, Role)
                                         VALUES (@Id, @Email, @Password, @Role);
                             """;

        var parameters = new { Id = Guid.NewGuid(), user.Email, user.Password, user.Role };
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        using IDbConnection connection = dbContext.CreateConnection();
        const string query = "SELECT * FROM Users";

        return await connection.QueryAsync<User>(query);
    }

    public async Task DeleteAllUser()
    {
        using IDbConnection connection = dbContext.CreateConnection();

        const string query = "DELETE FROM Users";
        await connection.ExecuteAsync(query);
    }
}