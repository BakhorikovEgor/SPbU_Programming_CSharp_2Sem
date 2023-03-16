namespace LZW;

using LZW.Utils;

internal static class Encoder
{
    public static byte[] Encode(byte[] bytes)
    {

        Trie trie = new Trie();
        ByteBuffer buffer = new ByteBuffer();

        uint newBitsSizeFlag = 512;
        for (uint i = 0; i < bytes.Length; i++)
        {
            if (trie.Size >= 65536)
            {
                trie = new Trie();
                buffer.CurrentNumberBitLength = 9;
                newBitsSizeFlag = 512;
            }

            uint number = trie.Add(i, bytes);
            if (trie.Size >= newBitsSizeFlag)
            {
                buffer.CurrentNumberBitLength++;
                newBitsSizeFlag <<= 1;
            }

            buffer.Add(number);   
        }

        buffer.AddToBufer();
        return buffer.Bytes.ToArray();
    }
}
