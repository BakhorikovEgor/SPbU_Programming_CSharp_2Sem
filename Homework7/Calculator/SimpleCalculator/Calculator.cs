namespace SimpleCalculator;

public class Calculator
{
    public double result { get; private set; } = 0;

    private int currentOperand = 0;
    private BinaryOperation.Operation currentOperation = BinaryOperation.Operation.Plus;

    public void AddOperandOrOperation(string item)
    {
        if (int.TryParse(item, out _))
        {
            foreach (var digit in item)
            {
                currentOperand = currentOperand * 10 + digit;
            }
        }
        else
        {
            result = BinaryOperation.Calculate(currentOperation, result, currentOperand);
            currentOperand = 0;

            currentOperation = item switch
            {
                "+" => BinaryOperation.Operation.Plus,
                "-" => BinaryOperation.Operation.Minus,
                "*" => BinaryOperation.Operation.Multiply,
                "/" => BinaryOperation.Operation.Divide,
                _ => throw new NotImplementedException()
            };
        }
    }

}
