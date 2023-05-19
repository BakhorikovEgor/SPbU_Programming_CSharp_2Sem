using System.Data;
using System.Security.Cryptography;

namespace Task1;

internal static class Compressor
{ 
    public static (byte[],double) Compress(byte[] data)
    {
        var result = new List<byte>();

        byte previousByte = data[0];
        byte counter = 0;
        foreach (byte b in data)
        {
            if (b == previousByte)
            {
                if (counter == byte.MaxValue)
                {
                    result.Add(byte.MaxValue);
                    result.Add(b);
                    counter = 0;
                }
                counter++;
            }
            else
            {
                result.Add(counter);
                result.Add(previousByte);

                counter = 1;
                previousByte = b;
            }
        }

        result.Add(counter);
        result.Add(previousByte);

        return (result.ToArray(), (double)data.Length / result.Count);
    }

    public static byte[] Decompress(byte[] data)
    {
        var result = new List<byte>();

        byte repeats = 0;
        for (var i = 0; i < data.Length; ++i)
        {
            if (i % 2 == 0)
            {
                repeats = data[i];
            }
            else
            {
                result.AddRange(Enumerable.Repeat(data[i], repeats));
            }
        }

        return result.ToArray();
    }
}
