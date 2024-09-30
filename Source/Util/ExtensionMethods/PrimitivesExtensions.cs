namespace TFirewall.Source.Util.ExtensionMethods;

public static class PrimitivesExtensions
{
    public static bool IsEven(this int source) => source % 2 == 0;
    public static bool IsOdd(this int source) => source % 2 == 1;
}