namespace LZW;

using LZW.Utils;

internal class Encoder
{
    public static List<uint> Encode(byte[] bytes)
    {
        Trie trie = new Trie();
        List<uint> result = new List<uint>();

        for (uint i = 0; i < bytes.Length; i++)
        {
            result.Add(trie.Add(i, bytes));
        }

        return result;
    }
}
