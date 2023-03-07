namespace Trees
{
    class Vertex
    {
        public Dictionary<char, Vertex> children;
        public bool IsTerminal { get; set; } = false;
        public int WordsNumber { get; set; } = 0;

        public Vertex()
        {
            children = new Dictionary<char, Vertex> ();
        }
        
    }
}