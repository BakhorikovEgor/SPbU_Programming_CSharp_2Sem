namespace LZW.Utils;


internal static class BWT
{
    public static (byte[], int) DirectTransformation(byte[] bytes)
    {
        var cyclicPermutations = new int[bytes.Length];
        for (var i = 0; i < bytes.Length; ++i)
        {
            cyclicPermutations[i] = i;
        }

        var endingPosition = BWTUtils.BWTShellSort(bytes, cyclicPermutations);
        List<byte> transformedBytes = new();
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

    public static byte[] ReverseTransformation(byte[] transformedBytes, int originalPosition)
    {
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