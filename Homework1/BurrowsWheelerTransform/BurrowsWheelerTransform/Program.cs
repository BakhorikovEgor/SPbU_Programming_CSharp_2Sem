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
        static int[] CountSort(string startedString, int position, int[] permutations)
        {
            // List to mark which permutations contain that letter at a given position.
            List<int>[] sameLetterPermutations = new List<int>[26];
            for (int i = 0; i < 26; ++i)
            {
                sameLetterPermutations[i] = new List<int>();
            }

            foreach (int firstInd in permutations)
            {
                sameLetterPermutations[startedString[(firstInd + position) % startedString.Length] - 'a'].Add(firstInd);
            }

            int sortedPosition = 0;
            for (int letterIndex = 0; letterIndex < 26; ++letterIndex)
            {
                for (int count = 0; count < sameLetterPermutations[letterIndex].Count; count++)
                {
                    permutations[sortedPosition] = sameLetterPermutations[letterIndex][count];
                    sortedPosition++;
                }
            }

            return permutations;
        }


        /// <summary>
        /// Sorts in alphabetical order the cyclic permutations of a string,
        /// represented as an array of pointers to the beginning of the permutation.
        /// </summary>
        static int[] AlphabetSort(string startedString, int[] permutations)
        {
            for (int position = startedString.Length - 1; position >= 0; --position)
            {
                CountSort(startedString, position, permutations);
            }
            return permutations;
        }


        static (string, int) DirectTransformation(string startedString)
        {
            // Array of pointers to the first elements for all cyclic permutations.
            int[] cyclicPermutations = new int[startedString.Length];
            for (int i = 0; i < startedString.Length; ++i)
            {
                cyclicPermutations[i] = i;
            }

            // Sort alphabetically cyclic permutation.
            AlphabetSort(startedString, cyclicPermutations);

            int endingPosition = 0;
            StringBuilder transformedString = new StringBuilder();
            for (int i = 0; i < startedString.Length; ++i)
            {
                char lastPermutaionElement = startedString[(cyclicPermutations[i] + startedString.Length - 1) % inputString.Length];
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
        /// in tranformation matrix, without building this matrix.
        /// </summary>
        static int[] BuildFirstPermutaionColumn(string transformedString)
        {
            // Build an array to mark the number of each letter inclusions.
            int[] firstColumnPointers = new int[26];
            for (int i = 0; i < transformedString.Length; ++i)
            {
                firstColumnPointers[transformedString[i] - 'a']++;
            }

            // Change array. It will present pointers to each
            // letter first inclusion in transformed matrix.
            int temporaryPointer = 0;
            for (int i = 0; i < firstColumnPointers.Length; ++i)
            {
                temporaryPointer += firstColumnPointers[i];
                firstColumnPointers[i] = temporaryPointer - firstColumnPointers[i];
            }

            return firstColumnPointers;
        }

        static string ReverseTransformation(string transformedString, int originalStringPosition)
        {

            int[] firstColumnPointers = BuildFirstPermutaionColumn(transformedString);

            // Create an array of pointers which bind previous array and given string
            // this array helps builing old string step by step.
            int[] reverseVector = new int[transformedString.Length];
            for (int i = 0; i < transformedString.Length; ++i)
            {
                reverseVector[firstColumnPointers[transformedString[i] - 'a']++] = i;
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
            WriteLine("Enter the string for transformation below (use only lower letters).");

            string? inputString = ReadLine();
            while (inputString == null || inputString.All(Char.IsLower) == false)
            {
                WriteLine("Wrong input.");
                WriteLine("Enter the string for transformation below (use only lower letters).");

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