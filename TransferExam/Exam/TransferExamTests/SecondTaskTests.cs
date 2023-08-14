using NUnit.Framework;

namespace TransferExamTests;

public class SecondTaskTests
{
    [TestCase ("()", true)]
    [TestCase("([<>])", true)]
    [TestCase("()[<>]()", true)]
    [TestCase("((()()()()))", true)]
    [TestCase("(", false)]
    [TestCase("([<>]", false)]
    public void IsBalancedTestWithCorrectInput(string input, bool result) 
        => Assert.That(SecondTask.IsBalanced(input).Equals(result), Is.True);
}
