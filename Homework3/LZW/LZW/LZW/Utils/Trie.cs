namespace LZW.Utils;


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

    public int Size { get; private set; } = 0;

    private readonly Vertex top = new();

    public Trie()
    {
        for (var i = 0; i < 256; ++i)
        {
            top.Children.Add((byte)i, new Vertex(Size++));
        }
    }

    public int Add(ref int startIndex, byte[] bytes)
    {
        var currentVertex = top;
        var shift = -1;
        for(var i = startIndex; i < bytes.Length; ++i)
        {
            var oneByte = bytes[i];
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