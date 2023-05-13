using Calculator;
using StackData;
using static System.Console;

class Program
{
    static void Main()
    {
        var calculator = new StackCalculator(new DynamicArrayStack());

        var choosing = true;
        string? stackType;
        while (choosing)
        {
            WriteLine("Hi, I`m calculator !");
            WriteLine("Сhoose what the stack should be based on");
            WriteLine("""

                1 - Dynamic Array
                2 - Linked List

                """);

            stackType = ReadLine();
            switch (stackType)
            {
                case "1":
                    choosing = false;
                    break;
                case "2":
                    calculator = new StackCalculator(new LinkedListStack());
                    choosing = false;
                    break;
                default:
                    WriteLine("\nWrong input\n");
                    break;
            }
        }

        var processing = true;
        while (processing)
        {
            WriteLine("\nEnter an expression(available operations: + - * /)\n");

            string? expression = ReadLine();
            try
            {
                double result = calculator.CalculateExpression(expression);
                WriteLine($"The result is: {result}");
            }
            catch (Exception ex) when (ex is ArgumentException ||
                                       ex is ArgumentNullException ||
                                       ex is InvalidOperationException ||
                                       ex is DivideByZeroException)

            {
                WriteLine(ex.Message);
            }

            Write("\nEnter 0 to exit: ");
            if (ReadLine() == "0")
            {
                processing = false;
            }
        }
    }
}