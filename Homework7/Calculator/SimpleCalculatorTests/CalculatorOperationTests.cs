using SimpleCalculator;

namespace SimpleCalculatorTests;

public class CalculatorOperationTest
{
    private readonly static double _delta = 0.001;
    private static bool AreDoublesEqual(double x, double y)
        => Math.Abs(x - y) < _delta;

    [TestCase(CalculatorOperation.Operations.ChangeSign, 1, -1)]
    [TestCase(CalculatorOperation.Operations.ChangeSign, -12.1, 12.1)]
    [TestCase(CalculatorOperation.Operations.ChangeSign, 0, 0)]
    public void ValidUnaryOperation_ShouldReturnExpectedValue(CalculatorOperation.Operations operation, double operand, double expected)
        => Assert.IsTrue(AreDoublesEqual(CalculatorOperation.Calculate(operation, operand), expected));

    [TestCase(CalculatorOperation.Operations.Plus,1)]
    [TestCase(CalculatorOperation.Operations.Minus, 0)]
    [TestCase(CalculatorOperation.Operations.Multiply, -1)]
    [TestCase(CalculatorOperation.Operations.Divide, 11)]
    public void BinaryOperationInsteadUnary_ShouldThrowArgumentException(CalculatorOperation.Operations operation, double operand)
        => Assert.Throws<ArgumentException>(() => CalculatorOperation.Calculate(operation, operand));

    [TestCase(CalculatorOperation.Operations.Plus, 1, 1, 2)]
    [TestCase(CalculatorOperation.Operations.Minus, 12, 34, -22)]
    [TestCase(CalculatorOperation.Operations.Multiply, 13.5, 4, 54.0)]
    [TestCase(CalculatorOperation.Operations.Divide, 4, 8 , 0.5)]
    public void ValidBinaryOperation_ShouldReturnExpectedValue(CalculatorOperation.Operations operation, double firstOperand,
                                                               double secondOperand, double expected)
     => Assert.IsTrue(AreDoublesEqual(CalculatorOperation.Calculate(operation, firstOperand, secondOperand), expected));

    [TestCase(CalculatorOperation.Operations.ChangeSign, -0.5, 123)]
    public void UnaryOperationInsteadBinary_ShouldThrowArgumentException(CalculatorOperation.Operations operation, double firstOperand, double secondOperand)
        => Assert.Throws<ArgumentException>(() => CalculatorOperation.Calculate(operation, firstOperand, secondOperand));

    [TestCase(CalculatorOperation.Operations.Divide, 10, 0)]
    [TestCase(CalculatorOperation.Operations.Divide, -10, 0)]
    [TestCase(CalculatorOperation.Operations.Divide, 0, 0)]
    public void DivisionByZero_ShouldThrowDivideByZeroException(CalculatorOperation.Operations operation, double firstOperand, double secondOperand)
        => Assert.Throws<DivideByZeroException>(() => CalculatorOperation.Calculate(operation, firstOperand, secondOperand));
}