namespace Trees
{
    /// <summary>
    /// Representation of a vertex and additional information about it.
    /// </summary>
    class Vertex
    {
        public Dictionary<char, Vertex> children = new Dictionary<char, Vertex>();

        // is there a word ending at this vertex.
        public bool IsTerminal { get; set; } = false;

        // the number of words containing this vertex as its part.
        public int WordsNumber { get; set; } = 0;

    }
}