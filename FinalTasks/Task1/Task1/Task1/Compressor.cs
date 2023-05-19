namespace ByteCompressor;

/// <summary>
/// Class with methods for compressing and decompressing byte sequences.
/// </summary>
public static class Compressor
{
    /// <summary>
    /// Byte compression method
    /// </summary>
    /// <param name="data"> Bytes to compress</param>
    /// <returns> Compressed bytes and compression ratio. </returns>
    /// <exception cref="InvalidDataException"> Data must not be empty. </exception>
    public static (byte[],double) Compress(byte[] data)
    {
        if (data.Length == 0)
        {
            throw new InvalidDataException("data can not be empty");
        }

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

    /// <summary>
    /// Byte decompression method.
    /// </summary>
    /// <param name="data"> Bytes to decompress. </param>
    /// <returns> Decompressed bytes, </returns>
    /// <exception cref="InvalidDataException"> Data must not be empty. </exception>
    public static byte[] Decompress(byte[] data)
    {

        if (data.Length == 0)
        {
            throw new InvalidDataException("data can not be empty");
        }

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
