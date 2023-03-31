namespace FuncMethodsTests;

public class Tests
{
    [Test]
    public void StandardMapTests_ShouldReturnExpectedList()
    {
        List<int> intList = new List<int> { 1, 9, 12, 13, 16, -45 };
        Func<int, int> intFunction = x => x * 10;
        List<int> expectedIntList = new List<int> { 10, 90, 120, 130, 160, -450 };

        List<int> actualIntList = FunctionalMethods.Map(intList, intFunction);

        Assert.That(actualIntList.SequenceEqual(expectedIntList), Is.True);
    }
}