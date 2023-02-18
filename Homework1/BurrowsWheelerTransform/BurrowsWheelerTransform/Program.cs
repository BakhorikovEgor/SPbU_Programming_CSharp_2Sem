using System.Text;
using static System.Console;


namespace BurrowsWheeler
{
    class Program
    {
        /// <summary>
        /// Sorts by counting the cyclic permutations of a string,
        /// represented by an array of pointers to the beginning of strings.
        /// Sort by a given position in each line.
        /// </summary>
        /// <param name="startedString"> String we use to take symbols from. </param>
        /// <param name="position"> Place in string where must sort. </param>
        /// <param name="permutations"> Pointers to the starts of cyclic permutations. </param>
        /// <returns> Sorted array of pointers the beginning of the permutations.</returns>
        static int[] CountSort(string startedString, int position, int[] permutations)
        {
            // List to mark which permutations contain that symbol at a given position.
            List<int>[] sameSymbolPermutations = new List<int>[128];
            for (int i = 0; i < 128; ++i)
            {
                sameSymbolPermutations[i] = new List<int>();
            }

            foreach (int firstIndex in permutations)
            {
                sameSymbolPermutations[startedString[(firstIndex + position) % startedString.Length]].Add(firstIndex);
            }

            int sortedPosition = 0;
            for (int letterIndex = 0; letterIndex < 128; ++letterIndex)
            {
                for (int count = 0; count < sameSymbolPermutations[letterIndex].Count; count++)
                {
                    permutations[sortedPosition] = sameSymbolPermutations[letterIndex][count];
                    sortedPosition++;
                }
            }

            return permutations;
        }


        /// <summary>
        /// Sorts in alphabetical order the cyclic permutations of a string,
        /// represented as an array of pointers to the beginning of the permutation.
        /// </summary>
        /// <param name="startedString"> String we use to take symbols from. </param>
        /// <param name="permutations"> Pointers to the starts of cyclic permutations. </param>
        /// <returns> Alphabetically sorted array of pointers to the beginning of the permutations.</returns>
        static int[] AlphabetSort(string startedString, int[] permutations)
        {
            for (int position = startedString.Length - 1; position >= 0; --position)
            {
                CountSort(startedString, position, permutations);
            }
            return permutations;
        }


        /// <summary>
        /// Trasnforming string by using BWT without creating full transformation matrix.
        /// </summary>
        /// <param name="startedString"> String we want to transform. </param>
        /// <returns> Transformed string and place of original string in transformation matrix.</returns>
        static (string, int) DirectTransformation(string startedString)
        {
            // Array of pointers to the first elements for all cyclic permutations.
            int[] cyclicPermutations = new int[startedString.Length];
            for (int i = 0; i < startedString.Length; ++i)
            {
                cyclicPermutations[i] = i;
            }

            AlphabetSort(startedString, cyclicPermutations);

            int endingPosition = 0;
            StringBuilder transformedString = new StringBuilder();
            for (int i = 0; i < startedString.Length; ++i)
            {
                char lastPermutaionElement = startedString[(cyclicPermutations[i] + startedString.Length - 1) % startedString.Length];
                transformedString.Append(lastPermutaionElement);

                if (cyclicPermutations[i] == 0)
                {
                    endingPosition = i;
                }
            }

            return (transformedString.ToString(), endingPosition);
        }


        /// <summary>
        /// Create an array of pointers to the elements of first column (first inclusions)
        /// in transformation matrix, without building this matrix.
        /// </summary>
        /// <param name="transformedString"> String we use as a last column in transformation matrix. </param>
        /// <returns> Array of pointers to the first inclusions of symblos in first column of transformation matrix. </returns>
        static int[] BuildFirstPermutaionColumn(string transformedString)
        {
            // Build an array to mark the number of each symbol inclusions.
            int[] firstColumnPointers = new int[128];
            for (int i = 0; i < transformedString.Length; ++i)
            {
                firstColumnPointers[transformedString[i]]++;
            }

            // Change array. It will present pointers to each
            // symbol first inclusion in transformation matrix.
            int temporaryPointer = 0;
            for (int i = 0; i < firstColumnPointers.Length; ++i)
            {
                temporaryPointer += firstColumnPointers[i];
                firstColumnPointers[i] = temporaryPointer - firstColumnPointers[i];
            }

            return firstColumnPointers;
        }

        /// <summary>
        /// Building original string by using one of cycling permutations without creating full transformation matrix.
        /// </summary>
        /// <param name="transformedString"> String after BWT. </param>
        /// <param name="originalStringPosition"> Position of string we want return in a transformation matrix </param>
        /// <returns> Original string. </returns>
        static string ReverseTransformation(string transformedString, int originalStringPosition)
        {

            int[] firstColumnPointers = BuildFirstPermutaionColumn(transformedString);

            // Create an array of pointers which bind previous array and given string
            // this array helps builing old string step by step.
            int[] reverseVector = new int[transformedString.Length];
            for (int i = 0; i < transformedString.Length; ++i)
            {
                reverseVector[firstColumnPointers[transformedString[i]]++] = i;
            }

            StringBuilder originalString = new StringBuilder();
            originalStringPosition = reverseVector[originalStringPosition];
            for (int i = 0; i < transformedString.Length; ++i)
            {
                originalString.Append(transformedString[originalStringPosition]);
                originalStringPosition = reverseVector[originalStringPosition];
            }

            return originalString.ToString();
        }


        static void Main()
        {
            WriteLine("Enter the string for transformation below (use symbols only from ascii table).");

            string? inputString = ReadLine();
            while (inputString == null || inputString.All(char.IsAscii) == false)
            {
                WriteLine("Wrong input.");
                WriteLine("Enter the string for transformation below (use symbols only from ascii table).");

                inputString = ReadLine();
            }

            (string, int) transformationInfo = DirectTransformation(inputString);
            string transformedString = transformationInfo.Item1;
            int oldStringPosition = transformationInfo.Item2;

            WriteLine($"Transformed string: {transformedString}");

            string oldString = ReverseTransformation(transformedString, oldStringPosition);

            WriteLine("Transformation way:");
            WriteLine($"{inputString} --> {transformedString} --> {oldString}");
        }
    }
}