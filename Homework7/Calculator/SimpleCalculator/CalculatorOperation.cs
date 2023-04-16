namespace SimpleCalculator;

internal static class CalculatorOperation
{
    private const double delta = 0.0001; 
    public enum Operations
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        ChangeSign
    }

    public static double Calculate (Operations operation, double operand)
        => operation == Operations.ChangeSign ? -operand : throw new NotImplementedException ();

    public static double Calculate(Operations operation, double firstOperand, double secondOperand = 0)
        => operation switch
        {
            Operations.Plus => firstOperand + secondOperand,
            Operations.Minus => firstOperand - secondOperand,
            Operations.Multiply => firstOperand * secondOperand,
            Operations.Divide => IsDoubleZero(secondOperand)
                                ? throw new DivideByZeroException()
                                : firstOperand / secondOperand,
            _ => throw new InvalidOperationException()
        };

    private static bool IsDoubleZero(double value)
        => Math.Abs(value) < delta;
}