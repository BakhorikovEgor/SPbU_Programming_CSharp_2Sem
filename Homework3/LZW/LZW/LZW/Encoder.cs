namespace LZW;

using LZW.Utils;

internal static class Encoder
{
    public static (byte[],bool) Encode(byte[] bytes)
    {

        Trie trie = new Trie();
        ByteBuffer buffer = new ByteBuffer();

        uint newBitsSizeFlag = 512;
        for (int i = 0; i < bytes.Length; i++)
        {
            if (trie.Size == 65536)
            {
                newBitsSizeFlag = 512;
                buffer.NumberBitLength = 9;
                trie = new Trie();
            }

            uint number = trie.Add(ref i, bytes);
            if (trie.Size == newBitsSizeFlag)
            {
                buffer.NumberBitLength++;
                newBitsSizeFlag <<= 1;
            }

            buffer.AddToEncode(number);   
        }

        if(buffer.currentByte != 0)
        {
            buffer.AddToBufer();
            return (buffer.Bytes.ToArray(), true);
        }
        buffer.AddToBufer();
        return (buffer.Bytes.ToArray(),true);
    }
}
