using Operations;
using StackData;

namespace Calculator
{
    /// <summary>
    /// Solver of expressions written in reverse Polish notation.
    /// </summary>
    public class StackCalculator
    {
        private readonly IStack stack;
        public StackCalculator(IStack stack)
        {
            this.stack = stack;
        }

        /// <summary>
        /// A method that calculates an expression written in reverse Polish notation.
        /// </summary>
        /// <param name="expression"> Expression in reverse Polish notation. </param>
        /// <returns> Value of expression. </returns>
        /// <exception cref="ArgumentException"> Expression can`t be solved. </exception>
        /// <exception cref="InvalidOperationException"> Stack is empty or unknown operation. </exception>
        /// <exception cref="ArgumentNullException"> Argument can`t be null. </exception>
        /// <exception cref="DivideByZeroException"> Second operand can`t be zero. </exception>
        public double CalculateExpression(string? expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("Expression can`t be null");
            }

            if (expression.Equals(String.Empty))
            {
                throw new ArgumentException("Expression can`t be empty");
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

            double result = stack.Pop();
            return stack.IsEmpty() 
                        ? result
                        : throw new ArgumentException("Expression is unsolvable");
        }

        private double CalculatePair(string operation)
        {
            double secondOperand = stack.Pop();
            double firstOperand = stack.Pop();
            return BinaryOperationSolver.Solve(operation, firstOperand, secondOperand);
        }
    }
}