using System.Text;


namespace LZW.Utils;

internal static class BWT
{
    internal static (byte[], int) DirectTransformation(byte[] bytes)
    {
        int[] cyclicPermutations = new int[bytes.Length];
        for (int i = 0; i < bytes.Length; ++i)
        {
            cyclicPermutations[i] = i;
        }


        int endingPosition = BWTUtils.DirectBWTSort(bytes, cyclicPermutations);

        List<byte> transformedBytes = new List<byte>();
        for (int i = 0; i < bytes.Length; ++i)
        {
            transformedBytes.Add(bytes[(cyclicPermutations[i] + bytes.Length - 1) % bytes.Length]);

            if (cyclicPermutations[i] == 0)
            {
                endingPosition = i;
            }
        }

        return (transformedBytes.ToArray(), endingPosition);
    }

}
