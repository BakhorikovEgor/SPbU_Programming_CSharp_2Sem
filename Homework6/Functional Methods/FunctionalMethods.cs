namespace Func;

public static class FunctionalMethods
{

    public static List<R> Map<T, R> (List<T> list, Func<T,R> function)
    {
        var result = new List<R>();
        foreach (var element in list)
        {
            result.Add(function(element));
        }
   
        return result;
    }

    public static List<T> Filter<T> (List<T> list, Func<T, bool> predicate)
    {
        var result = new List<T>();
        foreach (var element in list)
        {
            if (predicate(element))
            {
                result.Add(element);
            }
        }
        return result;
    }

    public static V Fold<T,V> (List<T> list,V accumulatedElement, Func<V,T,V> binaryFunction)
    {
        foreach (var element in list)
        {
            accumulatedElement = binaryFunction(accumulatedElement, element);
        }

        return accumulatedElement;
    }
}