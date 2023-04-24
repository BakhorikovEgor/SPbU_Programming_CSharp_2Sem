namespace SkipListTests;

public class Tests
{
    SkipList<int> _skipList;

    [SetUp]
    public void SetUp()
        => _skipList = new SkipList<int>();

    [Test]
    public void AddValue_ContainsShouldReturnTrue()
    {
        var value = -10;

        _skipList.Add(value);

        Assert.That(_skipList.Contains(value), Is.True);
    }

    [Test]
    public void ContainsNotExistingElement_ShouldReturnTrue()
        => Assert.That(_skipList.Contains(0), Is.False);


    [Test]
    public void AddAndRemoveAndContains_RemoveShouldReturnTrueContainsFalse()
    {
        var value = 8;

        _skipList.Add(value);

        Assert.That(_skipList.Remove(value), Is.True);
        Assert.That(_skipList.Contains(value), Is.False);
    }

    [Test]
    public void RemoveNotExistingElement_ShouldReturnFalse()
        => Assert.That(_skipList.Remove(1), Is.False);


    [Test]
    public void AddElementsAndGetIndexOneOfThem_ShouldReturnExpectedIndex()
    {
        Array.ForEach(new int[] { 0, 4, 5, 3, 2, 1 }, _skipList.Add);

        var value = 3;
        var index = 3;
        var expected = value;
        var actual = _skipList.IndexOf(index);

        Assert.That(actual.Equals(expected), Is.True);
    }

    [Test]
    public void IndexOfNotExistingElement_ShouldReturnMinusOne()
        => Assert.That(_skipList.IndexOf(99).Equals(-1), Is.True);

    [Test]
    public void InsertByIndex_ShouldThrowNotSupportedException()
        => Assert.Throws<NotSupportedException>(() => _skipList.Insert(0, 0));

    [Test]
    public void RemoveAtExistingIndex_ContainsShouldReturnFalse()
    {
        Array.ForEach(new int[] { 0, 4, 5, 3, 2, 1 }, _skipList.Add);

        var value = 2;
        var index = 2;

        _skipList.RemoveAt(index);

        Assert.That(_skipList.Contains(value), Is.False);
    }

    [Test]
    public void RemoveAtNotExistingIndex_ShouldThrowArgumentOutOfRangeException()
        => Assert.Throws<ArgumentOutOfRangeException>(() => _skipList.RemoveAt(0));

    [Test]
    public void AddAndClear_CountShouldReturnZero()
    {
        _skipList.Add(10);
        _skipList.Add(-10);
        _skipList.Clear();

        Assert.That(_skipList.Count.Equals(0), Is.True);
    }

    [Test]
    public void AddAndCopyTo_ShouldFillArrayCorrectly()
    {
        _skipList.Add(1);
        _skipList.Add(2);

        var expectedArray = new int[] { 1, 2 };

        var actualArray = new int[2];
        _skipList.CopyTo(actualArray, 0);

        Assert.That(actualArray.SequenceEqual(expectedArray), Is.True);
    }

    [Test]
    public void CopyToOutOfRange_ShouldThrowArgumentException()
        => Assert.Throws<ArgumentException>(() => _skipList.CopyTo(new int[] { 0 }, 1));

    [Test]
    public void CheckUsualIteration_ShouldGiveCorrectResult()
    {
        Array.ForEach(new int[] { 20, -15, 40, -10 }, _skipList.Add);
        
        var expected = new int[] { -15, -10, 20, 40 };

        var actual = new List<int>();
        foreach (var item in _skipList)
        {
            actual.Add(item);
        }

        Assert.That(actual.SequenceEqual(expected), Is.True);
    }

    [Test]
    public void ModifySkipListDuringIteration_ShouldThrowInvalidOperationException()
    {
        Array.ForEach(new int[] { 20, -15, 40, -10 }, _skipList.Add);
        
        var iterator = _skipList.GetEnumerator();

        _skipList.Remove(20);

        Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
    }

    [Test]
    public void StandardGet_ShouldReturnExpectedElement()
    {
        _skipList.Add(1);
        Assert.That(_skipList[0].Equals(1), Is.True);
    }

    public void StandartGetOutOfRange_ShouldThrowArgumentOutOfRangeException()
    {
        int i;
        Assert.Throws<ArgumentOutOfRangeException>(() => i = _skipList[0]);
    }
    [Test]
    public void StandardSet_ShouldThrowNotSupportedException()
        => Assert.Throws<NotSupportedException>(() => _skipList[0] = 1);

}
