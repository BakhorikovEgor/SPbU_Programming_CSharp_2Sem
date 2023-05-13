namespace LZW.Utils;

/// <summary>
/// A set of methods for direct and inverse Burrows-Wheeler transformations.
/// </summary>
internal class BWTUtils
{
    private static void Swap(ref int first, ref int second)
    {
        (first, second) = (second, first);
    }

    private static bool IsSuffixMore(byte[] bytes, int firstSuffixIndex, int secondSuffixIndex)
    {
        for (var i = 0; i < bytes.Length; ++i)
        {
            if (bytes[(firstSuffixIndex + i) % bytes.Length] != bytes[(secondSuffixIndex + i) % bytes.Length])
            {
                return bytes[(firstSuffixIndex + i) % bytes.Length] > bytes[(secondSuffixIndex + i) % bytes.Length];
            }
        }

        return false;
    }

    /// <summary>
    /// Sorting cyclic permutations of bytes represented by first element.
    /// </summary>
    /// <param name="bytes"> Initial sequence of bytes. </param>
    /// <param name="array"> First elements of cyclic permutations. </param>
    /// <returns> Ending position in cyclic permutation table (without building it). </returns>
    public static int BWTShellSort(byte[] bytes, int[] array)
    {
        var lastElement = 0;
        var partition = 1;

        while (partition < array.Length)
        {
            partition = (partition * 3) + 1;
        }

        partition /= 3;
        while (partition > 0)
        {
            for (var i = partition; i < array.Length; ++i)
            {
                for (var j = i; j - partition >= 0 && IsSuffixMore(bytes, array[j - partition], array[j]); j -= partition)
                {
                    if (j == lastElement || j - partition == lastElement)
                    {
                        lastElement = j == lastElement ? (j - partition) : j;
                    }

                    Swap(ref array[j], ref array[j - partition]);
                }
            }

            partition /= 3;
        }

        return lastElement;
    }

    /// <summary>
    /// Create first column of cyclic permutations table, without building this table.
    /// </summary>
    /// <param name="transformedBytes"> Sequence of bytes after reverse transformation. </param>
    /// <returns> First column of transformation table (without building it). </returns>
    public static int[] BuildFirstPermutationColumn(byte[] transformedBytes)
    {
        var firstColumnPointers = new int[256];
        for (var i = 0; i < transformedBytes.Length; ++i)
        {
            firstColumnPointers[transformedBytes[i]]++;
        }

        var temporaryPointer = 0;
        for (var i = 0; i < firstColumnPointers.Length; ++i)
        {
            temporaryPointer += firstColumnPointers[i];
            firstColumnPointers[i] = temporaryPointer - firstColumnPointers[i];
        }

        return firstColumnPointers;
    }
}