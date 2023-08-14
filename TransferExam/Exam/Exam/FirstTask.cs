namespace Exam;

public static class FirstTask
{
    public static int FindMostFrequentElement(int[] array)
    {
        var dict = new Dictionary<int, int>();

        int mostFrequentItem = -1;
        int maxFrequency = -1;

        foreach (int item in array)
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
