namespace Trees
{
    /// <summary>
    /// Trie data structure.
    /// </summary>
    class Trie
    {
        // "highest" vertex.
        private readonly Vertex top;

        // the number of existing vertexes.
        public int Size { get; private set; } = 1;

        public Trie()
        {
            top = new Vertex();
        }

        /// <summary>
        /// Was the word previously saved ?
        /// </summary>
        /// <param name="word"> searching word.</param>
        /// <returns> true / false </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Contains(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("Word can`t be null !");
            }

            if (word.Equals(string.Empty))
            {
                return true;
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
        /// <exception cref="ArgumentNullException"></exception>
        public bool Add(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("Word can`t be null !");
            }

            if (word.Equals(string.Empty) || Contains(word))
            {
                return false;
            }

            Vertex currentVertex = top;
            foreach (char symbol in word)
            {
                currentVertex.WordsNumber++;

                if (!currentVertex.children.ContainsKey(symbol))
                {
                    currentVertex.children.Add(symbol, new Vertex());
                    Size++;
                }

                currentVertex = currentVertex.children[symbol];
            }

            currentVertex.WordsNumber++;
            currentVertex.IsTerminal = true;

            return true;
        }

        /// <summary>
        /// Delete word from data structure.
        /// </summary>
        /// <param name="word"> deleating word. </param>
        /// <returns>  sucess of action. </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public bool Remove(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("Word can`t be null !");
            }

            if (word.Equals(string.Empty))
            {
                throw new ArgumentException("Empty word can`t be removed, it is always in trie !");
            }

            if (!Contains(word))
            {
                return false;
            }

            Vertex currentVertex = top;
            for (int i = 0; i < word.Length; ++i)
            {
                currentVertex.WordsNumber--;

                if (currentVertex.children[word[i]].WordsNumber == 1)
                {
                    currentVertex.children.Remove(word[i]);
                    Size -= word.Length - i; ;

                    return true;
                }

                currentVertex = currentVertex.children[word[i]];
            }

            currentVertex.WordsNumber--;
            currentVertex.IsTerminal = false;

            return true;
        }

        /// <summary>
        /// How many words we recorded that contain this prefix.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns> number of the words </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int HowManyStartsWithPrefix(string prefix)
        {
            if (prefix == null)
            {
                throw new ArgumentNullException("Prefix can`t be null !");
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
