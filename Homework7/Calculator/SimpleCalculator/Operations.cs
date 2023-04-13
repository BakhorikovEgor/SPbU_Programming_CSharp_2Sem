namespace SimpleCalculator;

internal static class BinaryOperation
{
    public enum Operation
    {
        Plus,
        Minus,
        Multiply,
        Divide
    }

    public static double Calculate(Operation operation, double leftOperand, int rightOperand)
    {
        return operation switch
        {
            Operation.Plus => leftOperand + rightOperand,
            Operation.Minus => leftOperand - rightOperand,
            Operation.Multiply => leftOperand * rightOperand,
            Operation.Divide => rightOperand == 0
                                ? throw new DivideByZeroException()
                                : leftOperand / rightOperand,

            _ => throw new NotImplementedException()
        };
    }


    
}
