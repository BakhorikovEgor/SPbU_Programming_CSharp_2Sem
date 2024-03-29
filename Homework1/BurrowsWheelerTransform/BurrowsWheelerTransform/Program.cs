﻿using static System.Console;

namespace BurrowsWheelerTransform
{
    class Program
    {
        static void Main()
        {
            WriteLine("Enter the string for transformation below (use symbols only from ascii table).");

            string? inputString = ReadLine();
            while (inputString == null || !inputString.All(char.IsAscii))
            {
                WriteLine("Wrong input.");
                WriteLine("Enter the string for transformation below (use symbols only from ascii table).");

                inputString = ReadLine();
            }

            (string transformedString, int oldStringPosition) = BWT.DirectTransformation(inputString);

            WriteLine($"Transformed string: {transformedString}");

            string oldString = BWT.ReverseTransformation(transformedString, oldStringPosition);

            WriteLine("Transformation way:");
            WriteLine($"{inputString} --> {transformedString} --> {oldString}");
        }
    }
}