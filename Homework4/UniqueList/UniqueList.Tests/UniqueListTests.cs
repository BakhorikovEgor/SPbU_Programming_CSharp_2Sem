namespace ListTests;

public class UniqueListTests
{
    private UniqueList list;

    [SetUp]
    public void Setup() => list = new UniqueList();

    [Test]
    public void AddSameElementTwice_ShouldThrowException()
    {
        var addElement = 1;
        list.Add(addElement);

        Assert.Throws<ElementAlreadyExistException>(() => list.Add(addElement));
    }

    [Test]
    public void RemoveNonExistenceElement_ShouldThrowException()
    {
        Assert.Throws<MissingElementException>(() => list.Remove(-1));
    }

    [Test]
    public void ReplaceElementToAlreadyExistingElement_ShouldReturnFalse()
    {
        list.Add(1);
        list.Add(2);

        var result = list.Replace(1, 0);

        Assert.That(result, Is.False);
    }
}
