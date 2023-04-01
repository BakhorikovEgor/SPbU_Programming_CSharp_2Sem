namespace MethodsTest;

public class Tests
{
    [Test]
    public void StandardMapTests_ShouldReturnExpectedList()
    {
        var intList = new List<int> { 1, 9, 12, 13, 16, -45 };
        var stringList = new List<string> { "Wubba", "Lubba", "Dub", "Dub" };

        var expectedTransformedIntList = new List<int> { 10, 90, 120, 130, 160, -450 };
        var expectedTransformedStringList = new List<int> { 5, 5, 3, 3 };

        var actualTransformedIntList = FunctionalMethods.Map(intList, x => x * 10);
        var actualTransformedStringList = FunctionalMethods.Map(stringList, s => s.Length);

        Assert.That(actualTransformedIntList.SequenceEqual(expectedTransformedIntList), Is.True);
        Assert.That(actualTransformedStringList.SequenceEqual(expectedTransformedStringList), Is.True);
    }

    [Test]
    public void StandardFilterTests_ShouldReturnExpectedList()
    {
        var intList = new List<int> { 3, 4, -10, -12, 8 };
        var stringList = new List<string> { "John", "Eric", "Tod", "Fred", "Oleg" };

        var expectedFilteredIntList = new List<int> { 3, 4 };
        var expectedFilteredStringList = new List<string> { "Oleg" };

        var actualFilteredIntList = FunctionalMethods.Filter(intList, x => Math.Abs(x - 3) <= 2);
        var actualFilteredStringList = FunctionalMethods.Filter(stringList, "Oleg".Equals);

        Assert.That(actualFilteredIntList.SequenceEqual(expectedFilteredIntList), Is.True);
        Assert.That(actualFilteredStringList.SequenceEqual(expectedFilteredStringList), Is.True);
    }

    [Test]
    public void StandardFoldTests_ShouldReturnExpectedAccumulatedValue()
    {
        var intList = new List<int> { 1, 2, 3, 4, 5, 6 };
        var stringList = new List<string> { "H", "e", "l", "l", "o" };

        var expectedIntAccumulatedElement = 21;
        var expectedStringAccumulatedElement = "Hello";

        var actualIntAccumulatedElement = FunctionalMethods.Fold(intList, 0, (x, y) => x + y);
        var actualStringAccumulatedElement = FunctionalMethods.Fold(stringList, "", (x, y) => x + y);

        Assert.That(actualIntAccumulatedElement.Equals(expectedIntAccumulatedElement), Is.True);
        Assert.That(actualStringAccumulatedElement.Equals(expectedStringAccumulatedElement), Is.True);
    }
}