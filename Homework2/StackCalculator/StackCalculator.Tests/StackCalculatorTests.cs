namespace StackCalculatorTests;

public class Tests
{
    private static IEnumerable<TestCaseData> TypesOfStack
    {
        get
        {
            yield return new TestCaseData(new StackCalculator(new DynamicArrayStack()));
            yield return new TestCaseData(new StackCalculator(new LinkedListStack()));
        }
    }

    [TestCaseSource(nameof(TypesOfStack))]
    public void CalculateCorrectExpression_ShouldReturnCorrectAnswer(StackCalculator calculator)
    {
        string expression = "14 12 - 2 * 4 / 5 6 + * 10 * 11 /";
        double expected = 10;

        double actual = calculator.CalculateExpression(expression);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(TypesOfStack))]
    public void CalculateUnsolvableExpression_ShouldThrowException(StackCalculator calculator)
    {
        string expression = "1 2 3 +";

        Assert.Throws<ArgumentException>(() => calculator.CalculateExpression(expression));

    }

    [TestCaseSource(nameof(TypesOfStack))]
    public void CalculateExpressionWithDivisionByZero_ShouldThrowException(StackCalculator calculator)
    {
        string expression = "1 0 /";

        Assert.Throws<DivideByZeroException>(() => calculator.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(TypesOfStack))]
    public void CalculateNullExpression_ShouldThrowException(StackCalculator calculator)
    {
        string? expression = null;

        Assert.Throws<ArgumentNullException>(() => calculator.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(TypesOfStack))]
    public void CalculateEmptyExpression_ShouldThrowException(StackCalculator calculator)
    {
        string expression = String.Empty;

        Assert.Throws<ArgumentException>(() => calculator.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(TypesOfStack))]
    public void CalculateExpressionWithInvalidSymbol_ShouldThrowException(StackCalculator calculator)
    {
        string? expression = "5 2 %";

        Assert.Throws<InvalidOperationException>(() => calculator.CalculateExpression(expression));
    }

}