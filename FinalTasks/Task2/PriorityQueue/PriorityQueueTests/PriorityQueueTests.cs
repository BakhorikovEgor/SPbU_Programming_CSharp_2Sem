using System.Linq.Expressions;


namespace PriorityQueueTests;

public class Tests
{
    PriorityQueue<int> queue;
    [SetUp]
    public void SetUp()
        => queue = new PriorityQueue<int>();

    [Test]
    public void AddElementsFromQueueAndGetItOneByOne_ShouldReturnValuesInExpectedOrder()
    {
        var elements = new (int Value, uint Priority)[] { (1, 1), (2, 2), (3, 3) };
        var expectedValues = new int[] { 3, 2, 1 };

        var actualValues = new int[3];

        foreach (var element in elements)
        {
            queue.Enqueue(element.Value, element.Priority);
        }
        for (var i = 0; i < 3; ++i)
        {
            actualValues[i] = queue.Dequeue();
        }

        Assert.That(actualValues.SequenceEqual(expectedValues), Is.True);
    }

    [Test]
    public void SamePriorityElementsAddAndGetItOneByOne_ShouldReturnValuesInExpectedOrder()
    {
        var elements = new (int Value, uint Priority)[] { (1, 1), (2, 1), (3, 1) };
        var expectedValues = new int[] { 1, 2, 3 };

        var actualValues = new int[3];

        foreach (var element in elements)
        {
            queue.Enqueue(element.Value, element.Priority);
        }
        for (var i = 0; i < 3; ++i)
        {
            actualValues[i] = queue.Dequeue();
        }

        Assert.That(actualValues.SequenceEqual(expectedValues), Is.True);
    }

    [Test]
    public void DequeueElementFromEmptyQueue_ShouldThrowExeption()
        => Assert.Throws<InvalidOperationException>(() => queue.Dequeue());


}