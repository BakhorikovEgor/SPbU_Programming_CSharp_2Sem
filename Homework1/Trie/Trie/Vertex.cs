namespace Trees
{
    class Vertex
    {
        public Dictionary<char, Vertex> children;
        public bool isTerminal = false;
        public int wordsNumber;


        public Vertex()
        {
            children = new Dictionary<char, Vertex> ();
        }
        
    }
}
