namespace LZW;

using LZW.Utils;

internal static class Encoder
{
    public static (uint[],byte[], bool) Encode(byte[] bytes)
    {

        Trie trie = new Trie();
        ByteBuffer buffer = new ByteBuffer();
        List<uint> data = new List<uint>();

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
            data.Add(number);
            buffer.AddToEncode(number);
        }

        if (buffer.CurrentByte != 0)
        {
            buffer.AddByteToBuffer();
            return (data.ToArray(),buffer.Bytes.ToArray(), true);
        }
        buffer.AddByteToBuffer();
        return (data.ToArray(),buffer.Bytes.ToArray(), false);
    }
}