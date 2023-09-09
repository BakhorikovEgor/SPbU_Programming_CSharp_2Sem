namespace Exam;

/// <summary>
/// Methods for first task of transfer exam
/// </summary>
public static class FirstTask
{
    /// <summary>
    /// Find the most frequent element in given array.
    /// </summary>
    /// <typeparam name="T"> Type of elements in array.</typeparam>
    /// <param name="array"> Given array. </param>
    /// <returns> The most frequent element in given array. </returns>
    /// <exception cref="ArgumentException"> Given array can not be empty. </exception>
    public static T? FindMostFrequentElement<T>(T[] array) where T : IComparable<T>
    {
        if (array.Length == 0)
        {
            throw new ArgumentException("No elements in given array");
        }

        var dict = new Dictionary<T, int>();
        var maxFrequency = -1;
        T? mostFrequentItem = default;

        foreach (var item in array)
        {
            dict[item] = dict.ContainsKey(item) 
                ? dict[item]++ 
                : 1;

            if (dict[item] > maxFrequency)
            {
                maxFrequency = dict[item];
                mostFrequentItem = item;
            }

        }

        return mostFrequentItem;
    }
}
