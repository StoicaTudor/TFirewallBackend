namespace TFirewall.Source.Util;

public static class ListUtils
{
    public static List<T> ConcatLists<T>(params List<T>[] listsToConcat)
    {
        List<T> concatResult = [];
    
        foreach (List<T> list in listsToConcat)
            concatResult.AddRange(list);
    
        return concatResult;
    }
}