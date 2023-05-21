namespace MethodsTest;

public class Tests
{
    [Test]
    public void StandardMapTests_ShouldReturnExpectedList()
    {
        var stringList = new List<string> { "Wubba", "Lubba", "Dub", "Dub" };
        
        var expectedTransformedStringList = new List<int> { 5, 5, 3, 3 };

        var actualTransformedStringList = FunctionalMethods.Map(stringList, s => s.Length);

        Assert.That(actualTransformedStringList.SequenceEqual(expectedTransformedStringList), Is.True);
    }

    [Test]
    public void StandardFilterTests_ShouldReturnExpectedList()
    {
        var intList = new List<int> { 3, 4, -10, -12, 8 };

        var expectedFilteredIntList = new List<int> { 3, 4 };

        var actualFilteredIntList = FunctionalMethods.Filter(intList, x => Math.Abs(x - 3) <= 2);

        Assert.That(actualFilteredIntList.SequenceEqual(expectedFilteredIntList), Is.True);
    }

    [Test]
    public void StandardFoldTests_ShouldReturnExpectedAccumulatedValue()
    {
        var stringList = new List<string> { "H", "e", "l", "l", "o" };

        var expectedStringAccumulatedElement = "Hello";

        var actualStringAccumulatedElement = FunctionalMethods.Fold(stringList, "", (x, y) => x + y);

        Assert.That(actualStringAccumulatedElement.Equals(expectedStringAccumulatedElement), Is.True);
    }

    [Test]
    public void FoldWithEmptyList_ShouldReturnStartedAccumulator()
    {
        var List = new List<string>();
        var startedAccumulator = "test";

    }
}