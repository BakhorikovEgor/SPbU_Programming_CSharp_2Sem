using Calculator.Operations;
using Calculator.StackData;

namespace Calculator
{
    internal class StackCalculator : IStackCalculator
    {
        private readonly IStack stack;
        public StackCalculator(IStack stack)
        {
            this.stack = stack;
        }

        public double CalculateExpression(string expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("Expression can`t be null");
            }

            string[] expressionParts = expression.Split();       
            foreach(string part in expressionParts)
            {
                if (int.TryParse(part, out int value))
                {
                    stack.Push(value);
                }
                else
                {
                    double calculatedPair = CalculatePair(part);
                    stack.Push(calculatedPair);
                }
            }

            if (stack.Count != 1)
            {
                throw new InvalidDataException("Expression is unsolvable");
            }

            return stack.Pop();
        }

        private double CalculatePair(string operation)
        {
            if (stack.Count < 2)
            {
                throw new InvalidDataException("Expression is unsolvable");
            }

            double secondOperand = stack.Pop();
            double firstOperand = stack.Pop();

            return BinaryOperationSolver.Solve(operation, firstOperand, secondOperand);

        }
    }
}
