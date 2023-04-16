namespace SimpleCalculator;

internal static class CalculatorOperation
{
    public enum Operation
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        ChangeSign,
        Equality,
    }

    public static double Calculate(Operation operation, double firstOperand, int secondOperand = 0)
        => operation switch
        {
            Operation.Plus => firstOperand + secondOperand,
            Operation.Minus => firstOperand - secondOperand,
            Operation.Multiply => firstOperand * secondOperand,
            Operation.ChangeSign => -firstOperand,
            Operation.Equality => firstOperand,
            Operation.Divide => secondOperand == 0
                                ? throw new DivideByZeroException()
                                : firstOperand / secondOperand,
            _ => throw new InvalidOperationException()
        };
}