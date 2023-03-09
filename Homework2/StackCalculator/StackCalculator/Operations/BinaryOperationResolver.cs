namespace Calculator.Operations
{
    /// <summary>
    /// Binary operations handler.
    /// </summary>
    internal static class BinaryOperationSolver
    {
        /// <summary>
        /// Binary operation ( + - * /).
        /// </summary>
        /// <param name="operation"> type of operator.</param>
        /// <param name="firstOperand"></param>
        /// <param name="secondOperand"></param>
        /// <returns>result of operation </returns>
        /// <exception cref="DivideByZeroException"> second operand can`t be zero</exception>
        /// <exception cref="InvalidOperationException"> operator must be + - * / </exception>
        public static double Solve(string? operation, double firstOperand, double secondOperand)
        {
            switch (operation)
            {
                case "+":
                    return firstOperand + secondOperand;
                case "-":
                    return firstOperand - secondOperand;
                case "*":
                    return firstOperand * secondOperand;
                case "/":
                    if (IsZero(secondOperand))
                    {
                        throw new DivideByZeroException("Second operand in division can`t be zero");
                    }
                    return firstOperand / secondOperand;
                default:
                    throw new InvalidOperationException("Operation must be + - * /");
            }
        }

        /// <summary>
        /// Checking whether a real number is equal to zero.
        /// </summary>
        /// <param name="number"> number we want to check.</param>
        /// <returns> Zero or not (true / false).</returns>
        private static bool IsZero(double number) => Math.Abs(number) < 0.00001;

    }
}
