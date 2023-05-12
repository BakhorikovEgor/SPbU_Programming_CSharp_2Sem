namespace StackCalculatorTests;

public class BinaryOperationSolverTests
{
    private bool DoubleEquality(double x, double y) => Math.Abs(x - y) < 0.0001;

    [Test]
    public void Add_ShouldReturnCorrectDouble()
    {
        var expected = 1.4 + 1.9;

        var actual = BinaryOperationSolver.Solve("+", 1.4, 1.9);

        Assert.That(DoubleEquality(expected, actual), Is.True);
    }

    [Test]
    public void Subtract_ShouldReturnCorrectDouble()
    {
        var expected = 7.8 - 9.1;

        var actual = BinaryOperationSolver.Solve("-", 7.8, 9.1);

        Assert.That(DoubleEquality(expected, actual), Is.True);
    }

    [Test]
    public void Multiply_ShouldReturnCorrectDouble()
    {
        var expected = 2.8 * 4.6;

        var actual = BinaryOperationSolver.Solve("*", 2.8, 4.6);

        Assert.That(DoubleEquality(expected, actual), Is.True);
    }

    [Test]
    public void Divide_WithoutZero_ReturnCorrectDouble()
    {
        var expected = 12.6 / 6.3;

        var actual = BinaryOperationSolver.Solve("/", 12.6, 6.3);

        Assert.That(DoubleEquality(expected, actual), Is.True);
    }

    [Test]
    public void Divide_SecondArgumentIsZero_ThrowException() 
        => Assert.Throws<DivideByZeroException>(() => BinaryOperationSolver.Solve("/", 3, 0));

    [Test]
    public void WrongOperation_ShouldThrowException()
        => Assert.Throws<InvalidOperationException>(() => BinaryOperationSolver.Solve("^", 1, 1));
}
