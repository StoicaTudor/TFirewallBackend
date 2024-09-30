namespace TFirewall.Source.Util.ExtensionMethods;

public static class EnumerableExtensions
{
    public static bool NoneRespects<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        return !source.Any(predicate);
    }
    
    public static bool DoesNotContain<T>(this IEnumerable<T> source, T value)
    {
        return !source.Contains(value);
    }
}