public class UniqueListTests
{
    private UniqueList uniqueList;

    [SetUp]
    public void Setup()
    {
        uniqueList = new UniqueList();
    }

    [Test]
    public void AddUniqueElementAndRemoveIt_ShouldReturnTrue()
    {
        var addValue = 0;
        uniqueList.Add(addValue);

        var actual = uniqueList.Remove(addValue);

        Assert.That(actual, Is.True);
    }

    [Test]
    public void AddUniqueElementAndReplaceToTheSame_ShouldReturnTrue()
    {
        var addValue = -1;
        uniqueList.Add(addValue);

        var actual = uniqueList.Replace(addValue, 0);

        Assert.That(actual, Is.True);
    }

    [Test]
    public void AddUniqueElementAndReplaceToDifferent_ShouldReturnTrue()
    {
        var addValue = 2;
        uniqueList.Add(addValue);

        var actual = uniqueList.Replace(3, 0);

        Assert.That(actual, Is.True);
    }

    [Test]
    public void ReplaceElementToAlreadyExistingElementNotEqualToThat_ShouldReturnFalse()
    {
        uniqueList.Add(1);
        uniqueList.Add(2);

        var actual = uniqueList.Replace(1, 0);

        Assert.That(actual, Is.False);
    }

    [Test]
    public void ReplaceNonExistenceElement_ShouldReturnFalse()
    {
        var actual = uniqueList.Replace(1, 0);

        Assert.That(actual, Is.False);
    }

    [Test] 
    public void ReplaceElementAtNonExistencePosition_ShouldReturnFalse()
    {
        var actual = uniqueList.Replace(1, 10);

        Assert.That(actual, Is.False);
    }

    [Test]
    public void AddSameElementTwice_ShouldThrowException()
    {
        var addElement = 1;
        uniqueList.Add(addElement);

        Assert.Throws<ElementAlreadyExistException>(() => uniqueList.Add(addElement));
    }

    [Test]
    public void RemoveNonExistenceElement_ShouldThrowException()
    {
        Assert.Throws<MissingElementException>(() => uniqueList.Remove(-1));
    }

}