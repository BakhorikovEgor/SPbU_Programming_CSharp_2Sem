﻿namespace Calculator.Operations
{
    internal static class BinaryOperationSolver
    {

        public static double Solve(string operation, double firstOperand, double secondOperand)
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
                        throw new DivideByZeroException("second operand can`t be zero");
                    }
                    return firstOperand / secondOperand;
                default:
                    throw new InvalidOperationException("Operation must be + - * /");
            }
        }

        private static bool IsZero(double number) => Math.Abs(number) < 0.00001;

    }
}
