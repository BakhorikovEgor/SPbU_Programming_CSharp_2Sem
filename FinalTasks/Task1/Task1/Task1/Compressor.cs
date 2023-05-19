using System.Data;
using System.Security.Cryptography;

namespace Task1;

internal static class Compressor
{ 
    private static readonly byte _maxByte = 255;
    public static (byte[],double) Compress(byte[] data)
    {

        var result = new List<byte>();

        byte previousByte = 0;
        byte counter = 0;
        foreach (byte b in data)
        {
            if (b == previousByte)
            {
                if (counter == _maxByte)
                {
                    result.Add(_maxByte);
                    result.Add(b);
                    counter = 0;
                }
                counter++;
            }
            else
            {
                if (counter > 1)
                {
                    result.Add(counter);
                }
                result.Add(previousByte);

                counter = 1;
                previousByte = b;
            }
        }

        return (result.ToArray(), (double)data.Length / result.Count);
    }
}
