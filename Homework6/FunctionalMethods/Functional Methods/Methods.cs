namespace Func;

public static class FunctionalMethods
{
    /// <summary>
    /// Applies the specified mapping to each element of the list.
    /// </summary>
    /// <typeparam name="T"> Type of elements in list. </typeparam>
    /// <typeparam name="R"> The type of the result after applying the mapping. </typeparam>
    /// <param name="list"> List of elements to transform. </param>
    /// <param name="function"> Element transform function. </param>
    /// <returns> List of converted elements of result type. </returns>
    public static List<R> Map<T, R>(List<T> list, Func<T, R> function)
    {
        var result = new List<R>();
        foreach (var element in list)
        {
            result.Add(function(element));
        }

        return result;
    }

    /// <summary>
    /// Filters the elements of the list by the given predicate.
    /// </summary>
    /// <typeparam name="T"> Type of elements in list. </typeparam>
    /// <param name="list"> List of elements to filter. </param>
    /// <param name="predicate"> Function that takes a value and returns a bool.</param>
    /// <returns> List of elements whose predicate evaluates to true. </returns> 
    public static List<T> Filter<T>(List<T> list, Func<T, bool> predicate)
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

    /// <summary>
    /// Accumulate the original value by the given function, passing through the list.
    /// </summary>
    /// <typeparam name="T"> Type of elements in list. </typeparam>
    /// <typeparam name="V"> Type of accumulating element. </typeparam>
    /// <param name="list"> List of elements for accumulation. </param>
    /// <param name="accumulatedElement"> Element we want to accumulate passing through the list. </param>
    /// <param name="binaryFunction"> Function of two arguments, with a non void return value</param>
    /// <returns></returns>
    public static V Fold<T, V>(List<T> list, V accumulatedElement, Func<V, T, V> binaryFunction)
    {
        foreach (var element in list)
        {
            accumulatedElement = binaryFunction(accumulatedElement, element);
        }

        return accumulatedElement;
    }
}
