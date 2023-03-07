namespace Trees
{
    class Trie
    {
        private readonly Vertex top;

        public int Size { get; private set; } = 0;

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
                return true ;
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

            return currentVertex.isTerminal;
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
                ++currentVertex.wordsNumber;

                if (!currentVertex.children.ContainsKey(symbol))
                {
                    currentVertex.children.Add(symbol, currentVertex);
                    ++Size;
                }

                currentVertex = currentVertex.children[symbol];
            }

            currentVertex.isTerminal = true;
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
                throw new ArgumentException("Empty word can`t be romoved, it is always in trie !");
            }

            if (!Contains(word))
            {
                return false;
            }

            Vertex currentVertex = top;
            foreach (char symbol in word)
            {
                --currentVertex.wordsNumber;
                currentVertex = currentVertex.children[symbol];
            }

            --currentVertex.wordsNumber;
            currentVertex.isTerminal = false;
            if (currentVertex.children.Count == 0)
            {
                Size -= word.Length;
            }

            return true;
        }

        public int HowManyStartsWithPrefix(String prefix)
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

            return currentVertex.wordsNumber;
        }

    }
}
