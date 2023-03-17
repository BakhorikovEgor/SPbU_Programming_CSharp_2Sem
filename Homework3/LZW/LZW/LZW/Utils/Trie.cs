namespace LZW.Utils;

internal class Trie
{
    private class Vertex
    {
        public Dictionary<byte, Vertex> Children { get; set; } = new Dictionary<byte, Vertex>();

        public uint Number { get; set; }

        public Vertex(uint number) 
        {
            Number = number;
        }

        public Vertex() { }

    }

    private readonly Vertex top = new Vertex();

    public uint Size { get; private set; } = 0;

    public Trie()
    {
        for (int i = 0; i < 256; ++i)
        {
            top.Children.Add((byte)i, new Vertex(Size++));
        }
    }

    public uint Add(ref int startIndex, params byte[] bytes)
    {

        Vertex currentVertex = top;
        int shift = -1;
        for(int i = startIndex; i < bytes.Length; ++i)
        {
            byte oneByte = bytes[i];
            if (!currentVertex.Children.ContainsKey(oneByte)) 
            {
                startIndex += shift;
                currentVertex.Children.Add(oneByte, new Vertex(Size++));
                return currentVertex.Number;
            }
            shift++;
            currentVertex = currentVertex.Children[oneByte];
        }
        startIndex += shift;
        return currentVertex.Number;
    }
}
