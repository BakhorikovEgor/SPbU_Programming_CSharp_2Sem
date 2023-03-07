using static System.Console;
using Trees;

class Program
{
    static Trie trie = new Trie();
    static void Main()
    {
        WriteLine("Hi, I am a builder of a data structure called \"Trie\"!");

        bool processing = true;
        while (processing)
        {
            WriteLine("""

                Choose one of the available operations:
                0 - exit
                1 - add word in Trie
                2 - check that the Trie contains word
                3 - remove word from Trie
                4 - show how many words in Trie starts with prefix
                5 - show Trie size

                """);

            string? choice = ReadLine();
            switch (choice)
            {
                case "0":
                    processing = false;
                    break;
                case "1":
                    Write("Enter the word: ");

                    string? word = ReadLine();
                    if (word != null)
                    {
                        bool result = trie.Add(word);
                        WriteLine(word + (result ? " is " : " isn`t ") + "added");
                    }
                    else
                    {
                        WriteLine("word can`t be null");
                    }

                    break;
                case "2":
                    Write("Enter the word: ");

                    word = ReadLine();
                    if (word != null)
                    {
                        bool result = trie.Contains(word);
                        WriteLine("trie " + (result ? "" : "doesn`t ") + " contains " + word);
                    }
                    else
                    {
                        WriteLine("word can`t be null");
                    }

                    break;
                case "3":
                    Write("Enter the word: ");

                    word = ReadLine();
                    if (word != null)
                    {
                        bool result = trie.Remove(word);
                        WriteLine(word + (result ? " is " : " isn`t ") + "removed");
                    }
                    else
                    {
                        WriteLine("word can`t be null");
                    }

                    break;
                case "4":
                    Write("Enter the prefix: ");

                    string? prefix = ReadLine();
                    WriteLine(prefix == null
                        ? "prefix can`t be null"
                        : $"{trie.HowManyStartsWithPrefix(prefix)} words start with {prefix}");

                    break;
                case "5":
                    WriteLine($"trie size: {trie.Size}");

                    break;
                default:
                    WriteLine("Incorrect input");

                    break;
            }
        }
    }
}