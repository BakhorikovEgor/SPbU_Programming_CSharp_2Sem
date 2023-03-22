using System.Text;

namespace BurrowsWheelerTransform
{
    internal static class BWT
    {
        /// <summary>
        /// Trasnforming string by using direct BWT without creating full transformation matrix.
        /// </summary>
        /// <param name="startedString"> String we want to transform. </param>
        /// <returns> Transformed string and place of original string in transformation matrix.</returns>
        internal static (string, int) DirectTransformation(string startedString)
        {
            // Array of pointers to the first elements for all cyclic permutations.
            var cyclicPermutations = new int[startedString.Length];
            for (var i = 0; i < startedString.Length; ++i)
            {
                cyclicPermutations[i] = i;
            }

            Array.Sort(cyclicPermutations, new BWTUtils.PermutationComparer(startedString));

            var endingPosition = 0;
            var transformedString = new StringBuilder();
            for (var i = 0; i < startedString.Length; ++i)
            {
                char lastPermutationElement = startedString[(cyclicPermutations[i] + startedString.Length - 1) % startedString.Length];
                transformedString.Append(lastPermutationElement);

                if (cyclicPermutations[i] == 0)
                {
                    endingPosition = i;
                }
            }

            return (transformedString.ToString(), endingPosition);
        }

        /// <summary>
        /// Building original string by using one of cycling permutations without creating full transformation matrix.
        /// </summary>
        /// <param name="transformedString"> String after BWT. </param>
        /// <param name="originalStringPosition"> Position of string we want return in a transformation matrix </param>
        /// <returns> Original string. </returns>
        internal static string ReverseTransformation(string transformedString, int originalStringPosition)
        {

            var firstColumnPointers = BWTUtils.BuildFirstPermutationColumn(transformedString);

            // Create an array of pointers which bind previous array and given string
            // this array helps builing old string step by step.
            var reverseVector = new int[transformedString.Length];
            for (var i = 0; i < transformedString.Length; ++i)
            {
                reverseVector[firstColumnPointers[transformedString[i]]++] = i;
            }

            var originalString = new StringBuilder();
            originalStringPosition = reverseVector[originalStringPosition];
            for (var i = 0; i < transformedString.Length; ++i)
            {
                originalString.Append(transformedString[originalStringPosition]);
                originalStringPosition = reverseVector[originalStringPosition];
            }

            return originalString.ToString();
        }
    }
}