﻿namespace LZW.Utils;

internal class BWTUtils
{

    private static void Swap(ref int first, ref int second)
    {
        (first, second) = (second, first);
    }

    private static bool IsSuffixMore(byte[] bytes, int firstSuffixIndex, int secondSuffixIndex)
    {

        for (int i = 0; i < bytes.Length; ++i)
        {
            if (bytes[(firstSuffixIndex + i) % bytes.Length] != bytes[(secondSuffixIndex + i) % bytes.Length])
            {
                return bytes[(firstSuffixIndex + i) % bytes.Length] > bytes[(secondSuffixIndex + i) % bytes.Length];
            }
        }

        return false;
    }


    public static int DirectBWTSort(in byte[] bytes, int[] array)
    {

        int lastElement = 0;
        int partition = 1;

        while (partition < array.Length)
        {
            partition = partition * 3 + 1;
        }

        partition /= 3;

        while (partition > 0)
        {
            for (int i = partition; i < array.Length; ++i)
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
}
