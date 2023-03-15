namespace LZW.Utils;

internal class Trie
{
    private class Vertex
    {
        static public readonly Vertex TOP = new Vertex();
        public Dictionary<byte, Vertex> Children { get; set; }

        public uint Number { get; set; }

        public Vertex(uint number) 
        {
            Number = number;
            Children = new Dictionary<byte, Vertex>();
        }

        private Vertex() 
        {
            Children = new Dictionary<byte, Vertex>();
        }

    }

    private readonly Vertex top;

    public uint Size { get; private set; }

    public Trie()
    {
        Size = 0;
        top = Vertex.TOP;
        for (int i = 0; i < 256; ++i)
        {
            Add(0, (byte)i);
        }
    }

    public uint Add(uint startIndex, params byte[] bytes)
    {

        Vertex currentVertex = top;
        for(uint i = startIndex; i < bytes.Length; ++i)
        {
            byte oneByte = bytes[i];
            if (!currentVertex.Children.ContainsKey(oneByte)) 
            {
                currentVertex.Children.Add(oneByte, new Vertex(Size++));
                return currentVertex.Number;
            }

            currentVertex = currentVertex.Children[oneByte];
        }

        return currentVertex.Number;
    }
}
