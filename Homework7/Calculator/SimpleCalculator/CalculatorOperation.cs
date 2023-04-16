namespace SimpleCalculator;


/// <summary>
/// A class that performs operations supported by the calculator.
/// </summary>
public static class CalculatorOperation
{
    private static readonly double _delta = 0.0001; 

    /// <summary>
    /// All available operations.
    /// </summary>
    public enum Operations
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        ChangeSign
    }

    /// <summary>
    /// Calculates operations with one operand.
    /// </summary>
    /// <returns> Result of operation. </returns>
    /// <exception cref="ArgumentException"> This operation is not a one operand operation. </exception>
    public static double Calculate (Operations operation, double operand)
        => operation == Operations.ChangeSign 
                     ? -operand 
                     : throw new ArgumentException("This is not supported operation");

    /// <summary>
    /// Calculates operations with two operands.
    /// </summary>
    /// <returns> Result of operation. </returns>
    /// <exception cref="DivideByZeroException"> Second operand in division can not be zero. </exception>
    /// <exception cref="ArgumentException"> This operation is not a two operands operation. </exception>
    public static double Calculate(Operations operation, double firstOperand, double secondOperand = 0)
        => operation switch
        {
            Operations.Plus => firstOperand + secondOperand,
            Operations.Minus => firstOperand - secondOperand,
            Operations.Multiply => firstOperand * secondOperand,
            Operations.Divide => IsDoubleZero(secondOperand)
                                ? throw new DivideByZeroException()
                                : firstOperand / secondOperand,
            _ => throw new ArgumentException("This is not supported operation")
        };

    private static bool IsDoubleZero(double value)
        => Math.Abs(value) < _delta;
}