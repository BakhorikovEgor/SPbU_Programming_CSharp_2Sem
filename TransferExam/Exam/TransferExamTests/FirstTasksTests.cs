using NUnit.Framework;

namespace TransferExamTests;

public class FirstTasksTests
{
    [TestCase(new int[] {1, 1, 1, 2, 3, 4}, 1)]
    [TestCase(new int[] { -1, -1, -1, 2, 2, 3, 4 }, -1)]
    [TestCase(new int[] { 13, 13, 12, 12}, 13)]
    public void FindMostFrequentElementTest_CorrectData(int[] array, int result)
        => Assert.That(FirstTask.FindMostFrequentElement(array).Equals(result), Is.True);

    [Test]
    public void FindMostFrequentElement_ThrowsArgumentExceptionWhenEmpty()
        => Assert.Throws<ArgumentException>(() => FirstTask.FindMostFrequentElement(new int[] { }));

}
