namespace GenericBubbleSortTests;

public class BubbleSortTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SortIntegerList_ShouldReturnSortedList()
    {
        IList<int> list = new List<int>() { 5, 4, 3, 2, 1 };
        IComparer<int> comparer = Comparer<int>.Default;

        IList<int> expected = new List<int>() { 1, 2, 3, 4, 5 };

        IList<int> actual = BubbleSort.Sort(list, comparer);
        
        
    }
}