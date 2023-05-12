namespace StackCalculatorTests;

internal class StackRealizationsTests
{

    private static IEnumerable<TestCaseData> TypesOfStack
    {
        get
        {
            yield return new TestCaseData(new DynamicArrayStack());
            yield return new TestCaseData(new LinkedListStack());
        }
    }

    [TestCaseSource(nameof(TypesOfStack))]
    public void AddAndPopTheSameNumberOfElements_StartedAndPopElementShouldBeEqual(IStack stack)
    {
        var expected = new double[] { 1.1, 2.0, 3.4, 0.0, -1.2 };
        foreach (var element in expected) 
        {
            stack.Push(element);
        }

        var actual = new List<double>();
        for (var i = 0; i < 5; ++i)
        {
            actual.Add(stack.Pop());
        }
        actual.Reverse();

        Assert.That(actual.SequenceEqual(expected), Is.True);
    }
    
    [TestCaseSource(nameof(TypesOfStack))]
    public void AddAndPopElements_IsEmptyShouldReturnTrue(IStack stack)
    {
        for (var i = 0; i < 10; ++i)
        {
            stack.Push(i);
        }

        for (var i = 0; i < 10; ++i)
        {
            stack.Pop();
        }

        Assert.That(stack.IsEmpty(), Is.True);
    }

    [TestCaseSource(nameof(TypesOfStack))]
    public void IsEmptyWithStartedStack_ShouldReturnTrue(IStack stack) 
        => Assert.That(stack.IsEmpty(), Is.True);

    [TestCaseSource(nameof(TypesOfStack))]
    public void PopEmptyStack_ShouldThrowException(IStack stack) 
        => Assert.Throws<InvalidOperationException>(() => stack.Pop());

    [TestCaseSource(nameof(TypesOfStack))]
    public void AddElementAndCheckIsEmpty_ShouldReturnFalse(IStack stack)
    {
        stack.Push(1);

        Assert.That(stack.IsEmpty(), Is.False);
    }
        


}
