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
        /// <exception cref="ArgumentNullException"> Null parametr. </exception>
        /// <exception cref="InvalidDataException"> Expression can`t be solved. </exception>
        public double CalculateExpression(string? expression)
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

            double result = stack.Pop();
            return stack.IsEmpty() 
                        ? result
                        : throw new InvalidDataException("Expression is unsolvable");
        }

        /// <summary>
        /// A method that performs a binary operation on operands.
        /// </summary>
        /// <param name="operation"> + - * / . </param>
        /// <returns> Value after operation. </returns>
        /// <exception cref="InvalidDataException"> Impossible to do operation. </exception>
        private double CalculatePair(string operation)
        {
            try
            {
                double secondOperand = stack.Pop();
                double firstOperand = stack.Pop();
                return BinaryOperationSolver.Solve(operation, firstOperand, secondOperand);
            }
            catch (Exception ex) when (ex is InvalidOperationException ||
                                       ex is DivideByZeroException)

            {
                throw new InvalidDataException(ex.Message);
            }
        }
    }
}