namespace GenericBubbleSortTests;

public class BubbleSortTests
{

    [Test]
    public void SortIntegerList_ShouldReturnSortedList()
    {
        IList<int> data = new List<int>() { 5, 4, 3, 2, 1 };
        IComparer<int> comparer = Comparer<int>.Default;

        IList<int> expected = new List<int>() { 1, 2, 3, 4, 5 };

        IList<int> actual = BubbleSort<int>.Sort(data, comparer);

        Assert.That(actual.SequenceEqual(expected), Is.True);
    }

    [Test]
    public void SortEmptyList_ShouldReturnEmptyList()
    {
        IList<string> data = new List<string>() { };
        IComparer<string> comparer = Comparer<string>.Default;

        IList<string> actual = BubbleSort<string>.Sort(data, comparer);

        Assert.That(actual.Count == 0, Is.True);
    }

    [Test]
    public void SortSortedList_ShouldReturnSame()
    {
        IList<string> data = new List<string>() {"aba", "caba", "waba"};
        IComparer<string> comparer = Comparer<string>.Default;

        IList<string> actual = BubbleSort<string>.Sort(data, comparer);

        Assert.That(actual.SequenceEqual(data), Is.True);
    }
}