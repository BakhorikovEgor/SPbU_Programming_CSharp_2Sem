namespace SimpleCalculatorTests;


//Результаты тестов целые, так как проверка на то,
//что с дробными все нормально была в тествх операций.
public class CalculatorTests
{
    private Calculator _calculator = new Calculator();

    [SetUp]
    public void SetUp()
        => _calculator = new Calculator();


    [TestCase('a')]
    [TestCase('b')]
    [TestCase('o')]
    public void AddInvalidDigit_MessageShouldBeNotANumber(char digit)
    {
        _calculator.AddDigit(digit);
        Assert.That(double.TryParse(_calculator.Message, out _), Is.False);
    }


    [TestCase("∙")]
    [TestCase("÷")]
    [TestCase("%")]
    [TestCase("mod")]
    public void AddInvalidOperation_MessageShouldBeNotANumber(string operation)
    {
        _calculator.AddOperation(operation);
        Assert.That(double.TryParse(_calculator.Message, out _), Is.False);
    }


    [Test]
    public void AddSomeDigitInStart_MessageShouldContainFullNumber()
    {
        _calculator.AddDigit('1');
        _calculator.AddDigit('2');
        _calculator.AddDigit('5');
        _calculator.AddOperation("+");

        Assert.That(_calculator.Message.Equals("125"), Is.True);
    }


    [Test]
    public void EnterSecondOperandAndChangeSign_MessageShouldNotBeChanged()
    {
        _calculator.AddDigit('1');
        _calculator.AddOperation("+");

        var expected = _calculator.Message;

        _calculator.AddDigit('1');
        _calculator.AddOperation("+/-");

        var actual = _calculator.Message;

        Assert.That(actual.Equals(expected), Is.True);
    }


    [Test]
    public void CalculateOperationAndChangeSign_MessageShouldChangeSign()
    {
        _calculator.AddDigit('5');
        _calculator.AddOperation("*");

        var expected = _calculator.Message;

        _calculator.AddOperation("+/-");

        var actual = _calculator.Message;

        Assert.That(actual.Equals("-" + expected), Is.True);
    }


    [Test]
    public void EnterNewOperation_MessageShouldContainResultOfOldOperation()
    {
        _calculator.AddDigit('6');
        _calculator.AddOperation("*");
        _calculator.AddDigit('5');
        _calculator.AddOperation("-");

        var expected = "30";

        var actual = _calculator.Message;

        Assert.That(actual.Equals(expected), Is.True);
    }


    [Test]
    public void CalculateWithoutSecondOperand_MessageShouldNotBeChanged()
    {
        _calculator.AddDigit('4');
        _calculator.AddOperation("*");
        _calculator.AddDigit('5');
        _calculator.AddOperation("-");
        _calculator.Calculate();

        var expected = "20";
        var actual = _calculator.Message;

        Assert.That(actual.Equals(expected), Is.True);
    }


    [Test]
    public void CalculateStandardOperationWithTwoOperand_MessageShouldBeResultOfOperation()
    {
        _calculator.AddDigit('3');
        _calculator.AddOperation("+/-");
        _calculator.AddOperation("/");
        _calculator.AddDigit('3');
        _calculator.Calculate();

        var expected = "-1";
        var actual = _calculator.Message;

        Assert.That(actual.Equals(expected), Is.True);
    }


    [Test]
    public void CalculateSecondOperandIsZero_MessageShouldNotBeANumber()
    {
        _calculator.AddDigit('1');
        _calculator.AddOperation("/");
        _calculator.AddDigit('0');
        _calculator.Calculate();

        Assert.That(double.TryParse(_calculator.Message, out _), Is.False);
    }


    [Test]
    public void ClearCalculator_MessageShouldBeZero()
    {
        _calculator.AddDigit('5');
        _calculator.AddOperation("+-/");
        _calculator.AddOperation("*");
        _calculator.AddDigit('1');
        _calculator.Clear();

        Assert.That(_calculator.Message.Equals("0"), Is.True);
    }
}
