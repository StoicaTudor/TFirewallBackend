using System.Data;
using MySqlConnector;
using TFirewall.Source.Util;

namespace TFirewall.Source.Persistence;

public class DbContext(IConfiguration configuration)
{
    public IDbConnection CreateConnection()
        => new MySqlConnection(configuration.GetConnectionString(Constants.DevSqlConnectionKey));
}