namespace LZW.Utils;

/// <summary>
/// Data structures for storing byte sequences
/// </summary>
internal class Trie
{
    private class Vertex
    {
        public Dictionary<byte, Vertex> Children { get; set; } = new();

        public int Number { get; set; }

        public Vertex(int number)
        {
            Number = number;
        }

        public Vertex() { }
    }

    /// <summary>
    /// A property that reflects the number of byte sequences
    /// </summary>
    public int Size { get; private set; } = 0;

    private readonly Vertex top = new();

    /// <summary>
    /// Standard constructor. To initialize the data structure with standard byte sequences.
    /// </summary>
    public Trie()
    {
        InitTree();
    }

    /// <summary>
    /// A method for adding a new byte sequence to the structure.
    /// </summary>
    /// <param name="startIndex"> The index starting from which to make the sequence. </param>
    /// <returns> The number of the nearest existing sequence before adding. </returns>
    public int Add(ref int startIndex, byte[] bytes)
    {
        if (bytes.Length == 0)
        {
            throw new InvalidDataException("Can`t handle empty byte sequence.");
        }
        var currentVertex = top;
        var shift = -1;

        for (var i = startIndex; i < bytes.Length; ++i)
        {
            var oneByte = bytes[i];
            if (!currentVertex.Children.ContainsKey(oneByte))
            {
                currentVertex.Children.Add(oneByte, new Vertex(Size++));
                break;
            }
            shift++;
            currentVertex = currentVertex.Children[oneByte];
        }

        startIndex += shift;
        return currentVertex.Number;
    }

    private void InitTree()
    {
        for (var i = 0; i < 256; ++i)
        {
            top.Children.Add((byte)i, new Vertex(Size++));
        }
    }
}