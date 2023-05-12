namespace ParsingTreeTests;

public class TreeTests
{
    private bool DoubleEquality(double x, double y)
        => Math.Abs(x - y) < 0.0001;

    [TestCase("(/ (* (- 2 5) (/ (+ 10 5) (* 5 1))) 3)", -3.0)]
    [TestCase("(/ (* 10 2) (+ 3 4))", 2.8571)]
    [TestCase("(* 0 0)", 0.0)]
    [TestCase("(- 123 34", 89.0)]
    [TestCase("(+ 1 1)", 2.0)]
    public void CorrectExpressionTest_ShouldReturnExpectedValue(string expression, double expected)
    {
        var tree = new Tree(expression);

        var actual = tree.Calculate();

        Assert.That(DoubleEquality(expected, actual), Is.True);
    }

    [Test]
    public void CorrectExpressionWithoutBrackets_ShouldReturnExpectedValue()
    {
        var expected = 1;
        var expression = "* / 2 4 / 4 2";
        var tree = new Tree(expression);

        var actual = tree.Calculate();

        Assert.That(DoubleEquality(expected, actual), Is.True);
    }

    [Test]
    public void DivideByZeroInExpression_ShouldThrowException()
    {
        var expression = "(/ (+ (* 10 10) (/ 2 2)) (- (+ 2 2) (* 1 4)))";
        var tree = new Tree(expression);

        Assert.Throws<DivideByZeroException>(() => tree.Calculate());
    }

    [TestCase("(+ 1 )")]
    [TestCase("( - 1 1)")]
    [TestCase("(1 1 +)")]
    public void InvalidInputFormat_ShouldThrowException(string expression)
        => Assert.Throws<WrongExpressionException>(() => new Tree(expression));

    [Test]
    public void EmptyExpression_ShouldThrowException()
     => Assert.Throws<WrongExpressionException>(() => new Tree(string.Empty));

    [Test]
    public void InvalidOperationInExpression_ShouldThrowException()
        => Assert.Throws<WrongExpressionException>(() => new Tree("(+ (- 1 1) (^ 2 2))"));
}