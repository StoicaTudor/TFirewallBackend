namespace TFirewall.Source.UserAppConfig.AppState;

using StackExchange.Redis;
using System;

public class RedisTest
{
    private static ConnectionMultiplexer redis;

    public static void Main()
    {
        // Connect to Redis
        redis = ConnectionMultiplexer.Connect("localhost:6379");
        Console.WriteLine("Connected to Redis");

        // Perform Redis actions
        SetValue("myKey", "myValue");
        string value = GetValue("myKey");
        Console.WriteLine($"Value for 'myKey': {value}");

        // Working with hashes
        SetHashValue("myHash", "field1", "value1");
        string hashValue = GetHashValue("myHash", "field1");
        Console.WriteLine($"Hash field 'field1': {hashValue}");

        // Close the connection
        redis.Close();
    }

    static void SetValue(string key, string value)
    {
        var db = redis.GetDatabase();
        db.StringSet(key, value);
    }

    static string GetValue(string key)
    {
        var db = redis.GetDatabase();
        return db.StringGet(key);
    }

    static void SetHashValue(string hashKey, string field, string value)
    {
        var db = redis.GetDatabase();
        db.HashSet(hashKey, field, value);
    }

    static string GetHashValue(string hashKey, string field)
    {
        var db = redis.GetDatabase();
        return db.HashGet(hashKey, field);
    }
}