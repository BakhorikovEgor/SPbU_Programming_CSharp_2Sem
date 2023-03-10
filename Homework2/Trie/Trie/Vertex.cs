namespace Trees
{
    /// <summary>
    /// Representation of a vertex and additional information about it.
    /// </summary>
    class Vertex
    {
        public Dictionary<char, Vertex> children = new Dictionary<char, Vertex>();

        /// <summary>
        /// is there a word ending at this vertex.
        /// </summary>
        public bool IsTerminal { get; set; } = false;

        /// <summary>
        /// the number of words containing this vertex as its part.
        /// </summary>
        public int WordsNumber { get; set; } = 0;

    }
}