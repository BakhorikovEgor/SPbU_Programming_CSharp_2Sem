using LZW.Utils;

namespace LZW;

internal static class Compressor
{
    public static byte[] Compress(byte[] bytes,int BWTPosition = -1)
    {

        var buffer = new ByteBuffer();
        var trie = new Trie();

        buffer.SetBWTPosition(BWTPosition);

        var newBitsSizeFlag = 512;
        for (var i = 0; i < bytes.Length; ++i)
        {
            if (trie.Size == newBitsSizeFlag)
            {
                buffer.NumberBitLength++;
                newBitsSizeFlag <<= 1;
            }

            if (trie.Size == 65536)
            {
                newBitsSizeFlag = 512;
                buffer.NumberBitLength = 9;
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