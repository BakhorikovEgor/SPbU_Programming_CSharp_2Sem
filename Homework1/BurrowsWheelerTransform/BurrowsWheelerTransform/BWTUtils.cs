namespace BurrowsWheelerTransform
{
    internal class BWTUtils
    {

        /// <summary>
        /// Comparer for permutation in alphabet order.
        /// </summary>
        internal class PermutationComparer : IComparer<int>
        {
            private string comparingPermutation;

            public PermutationComparer(string comparingPermutation)
            {
                this.comparingPermutation = comparingPermutation;
            }

            /// <summary>
            /// Comparing two permutations using comparing every char of this permutation.
            /// </summary>
            /// <param name="firstPointer"> Pointer to first element of permutation. </param>
            /// <param name="secondPointer"> Pointer to first element of permutation. </param>
            public int Compare(int firstPointer, int secondPointer)
            {
                for (int i = 0; i < comparingPermutation.Length; ++i)
                {
                    int innerComparison = comparingPermutation[(firstPointer + i) % comparingPermutation.Length]
                                         .CompareTo(comparingPermutation[(secondPointer + i) % comparingPermutation.Length]);
                    if (innerComparison != 0)
                    {
                        return innerComparison;
                    }
                }
                return 0;
            }
        }

        /// <summary>
        /// Create an array of pointers to the elements of first column (first inclusions)
        /// in transformation matrix, without building this matrix.
        /// </summary>
        /// <param name="transformedString"> String we use as a last column in transformation matrix. </param>
        /// <returns> Array of pointers to the first inclusions of symblos in first column of transformation matrix. </returns>
        internal static int[] BuildFirstPermutationColumn(string transformedString)
        {
            // Build an array to mark the number of each symbol inclusions.
            var firstColumnPointers = new int[128];
            for (int i = 0; i < transformedString.Length; ++i)
            {
                firstColumnPointers[transformedString[i]]++;
            }

            // Change array. It will present pointers to each
            // symbol first inclusion in transformation matrix.
            var temporaryPointer = 0;
            for (var i = 0; i < firstColumnPointers.Length; ++i)
            {
                temporaryPointer += firstColumnPointers[i];
                firstColumnPointers[i] = temporaryPointer - firstColumnPointers[i];
            }

            return firstColumnPointers;
        }
    }
}