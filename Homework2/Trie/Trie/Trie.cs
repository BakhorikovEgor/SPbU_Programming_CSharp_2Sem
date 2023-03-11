namespace Trees.Trie
{
    /// <summary>
    /// Trie data structure.
    /// </summary>
    class Trie
    {

        /// <summary>
        /// Representation of a vertex and additional information about it.
        /// </summary>
        private class Vertex
        {
            /// <summary>
            /// Vertex children.
            /// </summary>
            public Dictionary<char, Vertex> children { get; set; } = new Dictionary<char, Vertex>();

            /// <summary>
            /// Is there a word ending at this vertex.
            /// </summary>
            public bool IsTerminal { get; set; } = false;

            /// <summary>
            /// The number of words containing this vertex as its part.
            /// </summary>
            public int WordsNumber { get; set; } = 0;
        }

        // "highest" vertex.
        private readonly Vertex top = new Vertex();

        // the number of existing vertexes.
        public int Size { get; private set; } = 0;

        private bool isEmptyStringInTrie = false;

        /// <summary>
        /// Was the word previously saved ?
        /// </summary>
        /// <param name="word"> searching word.</param>
        /// <returns> true / false </returns>
        /// <exception cref="ArgumentNullException">null paramenr</exception>
        public bool Contains(string? word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("Word can`t be null !");
            }

            if (word.Equals(string.Empty))
            {
                return isEmptyStringInTrie;
            }

            Vertex currentVertex = top;
            foreach (char symbol in word)
            {
                if (!currentVertex.children.ContainsKey(symbol))
                {
                    return false;
                }

                currentVertex = currentVertex.children[symbol];
            }

            return currentVertex.IsTerminal;
        }

        /// <summary>
        /// Adding new word.
        /// </summary>
        /// <param name="word"> word to add.</param>
        /// <returns> did we added this word ? (or it is already exist) </returns>
        /// <exception cref="ArgumentNullException">null parametr</exception>
        public bool Add(string? word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("Word can`t be null !");
            }

            if (Contains(word))
            {
                return false;
            }

            if (word.Equals(String.Empty))
            {
                Size++;
                isEmptyStringInTrie = true;
                return true;
            }

            Vertex currentVertex = top;
            foreach (char symbol in word)
            {
                currentVertex.WordsNumber++;

                if (!currentVertex.children.ContainsKey(symbol))
                {
                    currentVertex.children.Add(symbol, new Vertex());
                }

                currentVertex = currentVertex.children[symbol];
            }

            Size++;
            currentVertex.WordsNumber++;
            currentVertex.IsTerminal = true;

            return true;
        }

        /// <summary>
        /// Delete word from data structure.
        /// </summary>
        /// <param name="word"> deleting word. </param>
        /// <returns>  success of action. </returns>
        /// <exception cref="ArgumentNullException">null parametr</exception>
        public bool Remove(string? word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("Word can`t be null !");
            }

            if (!Contains(word))
            {
                return false;
            }

            if (word.Equals(string.Empty))
            {
                Size--;
                isEmptyStringInTrie = false;
                return true;
            }

            Vertex currentVertex = top;
            foreach(char symbol in word)
            {
                currentVertex.WordsNumber--;              
                currentVertex = currentVertex.children[symbol];
            }

            Size--;
            currentVertex.WordsNumber--;
            currentVertex.IsTerminal = false;

            return true;
        }

        /// <summary>
        /// How many words we recorded that contain this prefix.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns> number of the words </returns>
        /// <exception cref="ArgumentNullException">null parametr</exception>
        public int HowManyStartsWithPrefix(string? prefix)
        {
            if (prefix == null)
            {
                throw new ArgumentNullException("Prefix can`t be null !");
            }

            if (prefix.Equals(String.Empty))
            {
                return Size;
            }

            Vertex currentVertex = top;
            foreach (char symbol in prefix)
            {
                if (!currentVertex.children.ContainsKey(symbol))
                {
                    return 0;
                }

                currentVertex = currentVertex.children[symbol];
            }

            return currentVertex.WordsNumber;
        }
    }
}
