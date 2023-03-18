using LZW.Utils;

namespace LZW;

/// <summary>
/// A class with functionality for compressing byte sequence using the LZW algorithm,
/// the TrIe data structure and (possibly) BWT.
/// </summary>
internal static class Compressor
{
    /// <summary>
    /// Сompresses a sequence of bytes.
    /// </summary>
    /// <param name="BWTPosition"> Position for reverse BWT in future for decompress.
    /// Add it in the beggining of new sequence. Standard value means lack of BWT.</param>
    /// <returns> Compressed byte sequence. </returns>
    public static byte[] Compress(byte[] bytes, int BWTPosition = -1)
    {
        if (bytes.Length == 0)
        {
            throw new ArgumentException("Can`t compress empty sequence of bytes.");
        }

        var buffer = new ByteBuffer();
        var trie = new Trie();

        buffer.Bytes.Add(0);
        buffer.SetBWTPosition(BWTPosition);

        var newBitsSizeFlag = 512;
        for (var i = 0; i < bytes.Length; ++i)
        {
            if (trie.Size == newBitsSizeFlag)
            {
                buffer.CurrentBitLength++;
                newBitsSizeFlag <<= 1;
            }

            if (trie.Size == 65536)
            {
                newBitsSizeFlag = 512;
                buffer.CurrentBitLength = 9;
                trie = new();
            }

            var number = trie.Add(ref i, bytes);
            buffer.AddNumber(number);
        }

        if (buffer.CurrentByte != 0)
        {
            buffer.Bytes[0] = 1;
        }

        buffer.AddByteToBuffer();
        return buffer.Bytes.ToArray();
    }
}