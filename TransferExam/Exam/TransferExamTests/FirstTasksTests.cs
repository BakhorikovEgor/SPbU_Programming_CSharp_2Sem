using NUnit.Framework;

namespace TransferExamTests;

public class FirstTasksTests
{
    [TestCase(new int[] {1, 1, 1, 2, 3, 4}, 1)]
    public void FindMostFrequentElementTest(int[] array, int result)
        => Assert.That(FirstTask.FindMostFrequentElement(array).Equals(result), Is.True);
}
