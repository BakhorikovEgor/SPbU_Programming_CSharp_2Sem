namespace Trees
{
    class Trie
    {
        private readonly Vertex top;

        public int Size { get; private set; } = 1;

        public Trie()
        {
            top = new Vertex();
        }

        public bool Contains (string word)
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
            foreach(char symbol in word)
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
                    int removedVertexsNumber = word.Length - i;
                    Size -= removedVertexsNumber;

                    return true;
                }

                currentVertex = currentVertex.children[word[i]];
            }

            currentVertex.WordsNumber--;
            currentVertex.IsTerminal = false;

            return true;
        }

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
