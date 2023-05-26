namespace GenericBubbleSort;

public static class BubbleSort<T>
{
    public static IList<T> Sort(IList<T> data, IComparer<T> comparer)
    {
        bool flag;
        for (var i = 0; i < data.Count; ++i)
        {
            flag = false;
            for (var j = 0; j < data.Count - i; ++j)
            {
                if (comparer.Compare(data[j], data[j + 1]) < 0)
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