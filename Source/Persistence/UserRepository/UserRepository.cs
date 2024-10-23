using System.Data;
using Dapper;
using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Persistence.UserRepository;

public class UserRepository(DbContext dbContext) : IUserRepository
{
    public async Task UpdateUserProfileAsync(UserProfile userProfile)
    {
        using IDbConnection connection = dbContext.CreateConnection();

        const string query = """
                                 UPDATE UserProfiles
                                 SET Content = @Content,
                                     Name = @Name,
                                     IsActiveProfile = @IsActiveProfile
                                 WHERE Id = @Id;
                             """;

        var parameters = new
        {
            userProfile.Content,
            userProfile.Name,
            userProfile.IsActiveProfile,
            userProfile.Id // Ensure that the Id is provided to identify the record to update
        };

        await connection.ExecuteAsync(query, parameters);
    }

    public async Task CreateUserProfile(UserProfile userProfile)
    {
        using IDbConnection connection = dbContext.CreateConnection();

        const string query = """
                                         INSERT INTO UserProfiles (Id, UserId, Content, Name, IsActiveProfile)
                                         VALUES (@Id, @UserId, @Content, @Name, @IsActiveProfile);
                             """;

        var parameters = new
        {
            Id = Guid.NewGuid(),
            userProfile.Content,
            userProfile.UserId,
            userProfile.Name,
            userProfile.IsActiveProfile,
        };

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
        const string query =
            "SELECT * FROM Users Users JOIN UserProfiles UserProfiles ON Users.Id = UserProfiles.UserId";

        Dictionary<string, User> userDictionary = new Dictionary<string, User>();
        IEnumerable<User> users = await connection.QueryAsync<User, UserProfile, User>(
            query,
            (user, profile) =>
            {
                if (!userDictionary.TryGetValue(user.Id, out var userEntry))
                {
                    userEntry = user;
                    userEntry.Profiles = [];
                    userDictionary.Add(userEntry.Id, userEntry);
                }

                userEntry.Profiles.Add(profile);

                return userEntry;
            }
        );

        return users.Distinct().ToList(); // Return distinct users
    }

    public async Task DeleteAllUser()
    {
        using IDbConnection connection = dbContext.CreateConnection();

        const string query = "DELETE FROM Users";
        await connection.ExecuteAsync(query);
    }

    public async Task DeleteUserProfileAsync(string profileId)
    {
        using IDbConnection connection = dbContext.CreateConnection();

        const string query = """
                                         DELETE FROM UserProfiles
                                         WHERE Id = @Id;
                             """;

        var parameters = new { Id = profileId };
        await connection.ExecuteAsync(query, parameters);
    }

    public void SetAllUserProfilesToInactive()
    {
        using IDbConnection connection = dbContext.CreateConnection();

        const string query = """
                                 UPDATE UserProfiles
                                 SET IsActiveProfile = false;
                             """;
        connection.Execute(query);
    }

    public async Task<UserProfile> GetActiveUserProfileAsync()
    {
        using IDbConnection connection = dbContext.CreateConnection();

        const string query =
            """
                        SELECT *
                         FROM UserProfiles 
                         WHERE IsActiveProfile = true;
            """;

        return (await connection.QueryAsync<UserProfile>(query)).First();
    }
}