namespace Exam;

public static class FirstTask
{
    public static int FindMostFrequentElement(int[] array)
    {
        var dict = new Dictionary<int, int>();

        var mostFrequentItem = -1;
        var maxFrequency = -1;

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
