using Calculator.Operations;
using Calculator.StackData;

namespace Calculator
{
    /// <summary>
    /// Solver of expressions written in reverse Polish notation.
    /// </summary>
    internal class StackCalculator
    {
        private readonly IStack stack;
        public StackCalculator(IStack stack)
        {
            this.stack = stack;
        }

        /// <summary>
        /// A method that calculates an expression written in reverse Polish notation.
        /// </summary>
        /// <param name="expression"> Expression in reverse Polish notation</param>
        /// <returns> Value of expression </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidDataException"></exception>
        public double CalculateExpression(string expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("Expression can`t be null");
            }

            string[] expressionParts = expression.Split();
            foreach (string part in expressionParts)
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

        /// <summary>
        /// A method that performs a binary operation on operands.
        /// </summary>
        /// <param name="operation"> + - * / </param>
        /// <returns> Value after operation </returns>
        /// <exception cref="InvalidDataException"></exception>
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
