namespace LZW;

using LZW.Utils;

internal static class Encoder
{
    public static (byte[], bool) Encode(byte[] bytes)
    {

        Trie trie = new Trie();
        ByteBuffer buffer = new ByteBuffer();

        uint newBitsSizeFlag = 512;
        for (int i = 0; i < bytes.Length; ++i)
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
                trie = new Trie();
            }

            uint number = trie.Add(ref i, bytes);
            buffer.AddToEncode(number);
        }

        if (buffer.CurrentByte != 0)
        {
            buffer.AddByteToBuffer();
            return (buffer.Bytes.ToArray(), true);
        }
        buffer.AddByteToBuffer();
        return (buffer.Bytes.ToArray(), false);
    }
}