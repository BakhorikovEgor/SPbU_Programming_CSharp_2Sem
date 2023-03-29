using System.Security.Cryptography.X509Certificates;

namespace ParsingTreeTests;

public class TreeTests
{

    private bool DoubleEquality(double x, double y)
        => Math.Abs(x - y) < 0.0001;

    [Test]
    public void CorrectExpressionTest_ShouldReturnTrueValue()
    {
        var expected = -3;
        var expression = "(/ (* (- 2 5) (/ (+ 10 5) (* 5 1))) 3)";
        Tree tree = new Tree(expression);

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

    [Test]
    public void EmptyExpression_ShouldThrowException()
        => Assert.Throws<InvalidDataException>(() => new Tree(string.Empty));

    [Test]
    public void InvalidInputFormat_ShouldThrowException()
        => Assert.Throws<InvalidDataException>(() => new Tree("( + 1 )"));

    [Test]
    public void InvalidOperationInExpression_ShouldThrowException()
        => Assert.Throws<ArgumentException>(() => new Tree("(+ (- 1 1) (^ 2 2))"));

}