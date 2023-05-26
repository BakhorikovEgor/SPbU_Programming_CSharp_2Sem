namespace GenericBubbleSort;

/// <summary>
/// Class contains method to sort list by bubble sort.
/// </summary>
/// <typeparam name="T"> Type of element in list</typeparam>
public static class BubbleSort<T>
{
    /// <summary>
    /// Classic bubble sort algorithm.
    /// </summary>
    /// <param name="data"> Give list. </param>
    /// <param name="comparer"> How to compare T elements. </param>
    /// <returns> Sorted list. </returns>
    public static IList<T> Sort(IList<T> data, IComparer<T> comparer)
    {
        bool flag;
        for (var i = 0; i < data.Count; ++i)
        {
            flag = false;
            for (var j = 0; j < data.Count - i - 1; ++j)
            {
                if (comparer.Compare(data[j], data[j + 1]) > 0)
                {
                    Swap(data, j, j + 1);
                    flag = true;
                }
            }

            if (!flag)
            {
                break;
            }
        }
        return data;
    }

    private static void Swap(IList<T> data, int index1, int index2)
    {
        var temp = data[index1];
        data[index1] = data[index2];
        data[index2] = temp;
    }
}