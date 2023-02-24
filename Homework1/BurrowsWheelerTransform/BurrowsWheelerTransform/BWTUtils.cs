namespace BurrowsWheelerTransform
{
    internal class BWTUtils
    {
        /// <summary>
        /// Sorts by counting the cyclic permutations of a string,
        /// represented by an array of pointers to the beginning of strings.
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
        internal static int[] AlphabetSort(string startedString, int[] permutations)
        {
            for (int position = startedString.Length - 1; position >= 0; --position)
            {
                CountSort(startedString, position, permutations);
            }
            return permutations;
        }

        /// <summary>
        /// Create an array of pointers to the elements of first column (first inclusions)
        /// in transformation matrix, without building this matrix.
        /// </summary>
        /// <param name="transformedString"> String we use as a last column in transformation matrix. </param>
        /// <returns> Array of pointers to the first inclusions of symblos in first column of transformation matrix. </returns>
        internal static int[] BuildFirstPermutaionColumn(string transformedString)
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
    }
}