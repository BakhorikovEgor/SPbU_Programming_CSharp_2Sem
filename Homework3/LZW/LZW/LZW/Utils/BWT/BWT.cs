namespace LZW.Utils;


/// <summary>
/// A class for applying the forward and reverse 
/// Barrows-Wheeler transformations to a sequence of bytes.
/// </summary>
internal static class BWT
{
    /// <summary>
    /// Direct Barrows-Wheeler transformation.
    /// </summary>
    /// <param name="bytes"> The initial sequence of bytes. </param>
    /// <returns> Transformed sequence and position of byte for reverse transformation.</returns>
    public static (byte[], int) DirectTransformation(byte[] bytes)
    {
        if (bytes.Length == 0)
        {
            throw new ArgumentException("Can`t handle empty byte sequence.");
        }

        var cyclicPermutations = new int[bytes.Length];
        for (var i = 0; i < bytes.Length; ++i)
        {
            cyclicPermutations[i] = i;
        }

        var endingPosition = BWTUtils.BWTShellSort(bytes, cyclicPermutations);
        var transformedBytes = new List<byte>();
        for (var i = 0; i < bytes.Length; ++i)
        {
            transformedBytes.Add(bytes[(cyclicPermutations[i] + bytes.Length - 1) % bytes.Length]);
            if (cyclicPermutations[i] == 0)
            {
                endingPosition = i;
            }
        }

        return (transformedBytes.ToArray(), endingPosition);
    }

    /// <summary>
    /// Reverse Barrows-Wheeler transformation.
    /// </summary>
    /// <param name="transformedBytes"> Sequence of bytes after direct transformation. </param>
    /// <param name="originalPosition"> The byte position representing one of the cyclic permutations. </param>
    /// <returns> Sequence before direct transformation. </returns>
    /// <exception cref="InvalidDataException"> Position in original sequence isn`t negative number. </exception>
    public static byte[] ReverseTransformation(byte[] transformedBytes, int originalPosition)
    {
        if (originalPosition < 0)
        {
            throw new ArgumentException("Position can`t be negative !");
        }

        if (transformedBytes.Length == 0)
        {
            throw new ArgumentException("Can`t handle empty byte sequence.");
        }

        var firstColumnPointers = BWTUtils.BuildFirstPermutationColumn(transformedBytes);

        var reverseVector = new int[transformedBytes.Length];
        for (var i = 0; i < transformedBytes.Length; ++i)
        {
            reverseVector[firstColumnPointers[transformedBytes[i]]++] = i;
        }

        var originalBytes = new byte[transformedBytes.Length];
        originalPosition = reverseVector[originalPosition];
        for (var i = 0; i < transformedBytes.Length; ++i)
        {
            originalBytes[i] = transformedBytes[originalPosition];
            originalPosition = reverseVector[originalPosition];
        }

        return originalBytes;
    }
}