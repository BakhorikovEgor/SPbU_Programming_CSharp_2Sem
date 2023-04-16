namespace SimpleCalculator;

public class Calculator
{
    public double result { get; private set; } = 0;
    public bool IsResultExist { get; private set; } = false;

    private int currentOperand = 0;
    private bool isCurrentOperandExist = false;
    private CalculatorOperation.Operation currentOperation = CalculatorOperation.Operation.Equality;

    public void AddOperandOrOperation(string item)
    {
        if (int.TryParse(item, out _))
        {
            foreach (var digit in item)
            {
                currentOperand = currentOperand * 10 + digit - '0';
            }
            isCurrentOperandExist = true;

            if (!IsResultExist)
            {
                IsResultExist = true;
                result = currentOperand;

                isCurrentOperandExist = false;
                currentOperand = 0;
            }
        
        }
        else
        {
            
            if (currentOperation == CalculatorOperation.Operation.ChangeSign)
            {
                if (isCurrentOperandExist)
                {
                    currentOperand = (int)CalculatorOperation.Calculate(currentOperation, currentOperand);
                }
                else
                {
                    result = CalculatorOperation.Calculate(currentOperation, result);
                }
            }
            else
            {
                result = CalculatorOperation.Calculate(currentOperation, result, currentOperand);
                isCurrentOperandExist = false;
                currentOperand = 0;
            }

            currentOperation = item switch
            {
                "+" => CalculatorOperation.Operation.Plus,
                "-" => CalculatorOperation.Operation.Minus,
                "*" => CalculatorOperation.Operation.Multiply,
                "/" => CalculatorOperation.Operation.Divide,
                "=" => CalculatorOperation.Operation.Equality,
                _ => throw new InvalidOperationException()
            };
        }
    }

}
