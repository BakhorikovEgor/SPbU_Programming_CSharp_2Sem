namespace ListTests;
public class UniqueAndStandardListTests
{
    private static IEnumerable<TestCaseData> TypesOfList()
    => new TestCaseData[]
       {
           new TestCaseData(new StandardList()),
           new TestCaseData(new UniqueList())
       };

    [TestCaseSource(nameof(TypesOfList))]
    public void AddUniqueElementAndRemoveIt_ShouldReturnTrue(StandardList list)
    {
        var addValue = 0;
        list.Add(addValue);

        var result = list.Remove(addValue);

        Assert.That(result, Is.True);
    }

    [TestCaseSource(nameof(TypesOfList))]
    public void AddUniqueElementAndReplaceToTheSame_ShouldReturnTrue(StandardList list)
    {
        var addValue = -1;
        list.Add(addValue);

        var result = list.Replace(addValue, 0);

        Assert.That(result, Is.True);
    }

    [TestCaseSource(nameof(TypesOfList))]
    public void AddUniqueElementAndReplaceToDifferentUniqueElement_ShouldReturnTrue(StandardList list)
    {
        var addValue = 2;
        list.Add(addValue);

        var result = list.Replace(3, 0);

        Assert.That(result, Is.True);
    }

    [TestCaseSource(nameof(TypesOfList))]
    public void ReplaceElementAtNonExistencePosition_ShouldReturnFalse(StandardList list)
    {
        list.Add(1);
        var result = list.Replace(1, 1);

        Assert.That(result, Is.False);
    }

    [TestCaseSource(nameof(TypesOfList))]
    public void ReplaceElementToTheSame_ShouldReturnTrue(StandardList list)
    {
        list.Add(1);
        list.Add(2);

        var result = list.Replace(1, 1);

        Assert.That(result, Is.True);
    }


}