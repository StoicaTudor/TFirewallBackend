using System.Text.Json;

namespace TFirewall.Source.FirewallCore.Services;

public class JsonValidator : IJsonValidator
{
    public bool IsValid(string json)
    {
        try
        {
            JsonDocument.Parse(json);
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}