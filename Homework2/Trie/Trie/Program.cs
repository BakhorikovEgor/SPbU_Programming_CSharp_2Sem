using Trees;
using static System.Console;

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
                    try
                    {
                        bool result = trie.Add(word);
                        WriteLine(word + (result ? " is " : " isn`t ") + "added");
                    }
                    catch (ArgumentNullException ex)
                    {
                        WriteLine(ex.Message);
                    }
                    break;

                case "2":
                    Write("Enter the word: ");

                    word = ReadLine();
                    try
                    {
                        bool result = trie.Contains(word);
                        WriteLine("trie " + (result ? "" : "doesn`t ") + " contains " + word);
                    }
                    catch(ArgumentNullException ex)
                    {
                        WriteLine(ex.Message);
                    }
                    break;

                case "3":
                    Write("Enter the word: ");

                    word = ReadLine();
                    try
                    {
                        bool result = trie.Remove(word);
                        WriteLine(word + (result ? " is " : " isn`t ") + "removed");
                    }
                    catch (Exception ex) when (ex is ArgumentException ||
                                               ex is ArgumentNullException)
                    {
                        WriteLine(ex.Message);
                    }
                    break;

                case "4":
                    Write("Enter the prefix: ");

                    string? prefix = ReadLine();
                    try
                    {
                        WriteLine($"{trie.HowManyStartsWithPrefix(prefix)} words start with {prefix}");
                    }
                    catch(ArgumentNullException ex)
                    {
                        WriteLine(ex.Message);
                    }
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