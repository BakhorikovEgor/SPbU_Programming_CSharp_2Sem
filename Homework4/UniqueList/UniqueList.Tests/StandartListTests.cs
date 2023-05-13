namespace ListTests;

internal class StandardListTests
{
    private StandardList list;

    [SetUp]
    public void Setup() => list = new StandardList();

    [Test]
    public void RemoveNonExistenceElement_ShouldReturnFalse()
    {
        var result = list.Remove(0);

        Assert.That(result, Is.False);
    }

    [Test]
    public void AddSameElementTwice_ShouldNotThrowException()
    {
        list.Add(1);
        list.Add(1);
    }

    [Test]
    public void ReplaceElementToAlreadyExistence_ShouldReturnTrue()
    {
        list.Add(111);
        list.Add(-111);

        Assert.That(list.Replace(111, 0), Is.True);
    }
}
