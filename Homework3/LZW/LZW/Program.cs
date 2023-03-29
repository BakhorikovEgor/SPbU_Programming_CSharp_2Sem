using static System.Console;
using LZW;


if (args[0] == "-help")
{
    WriteLine("""
        This program is for compressing binary files using the Lempel-Ziv-Welch and Burrows-Wheeler algorithms.
        How to use:

        To compress:
        - - - - - - - - - - - - - - - - - - - - - - - - 
        dotnet run [file path] --c
        (If the path contains spaces -> enclose it in quotes)
        - - - - - - - - - - - - - - - - - - - - - - - - 
        
        To decompress:
        - - - - - - - - - - - - - - - - - - - - - - - - 
        dotnet run [file(.zipped) path] --u
        (If the path contains spaces -> enclose it in quotes)
        - - - - - - - - - - - - - - - - - - - - - - - - 
        """);
    return 0;
}

if (args.Length < 2)
{
    WriteLine("Two arguments are needed");
    WriteLine("For help, use the command: dotnet run -help");
}

else if (args[1] == "--c")
{
    WriteLine("Handling...");
    try
    {
        CompressHandler.CompressWithAndWithoutBWT(args[0]);
        WriteLine("\nDone");
    }
    catch (FileNotFoundException)
    {
        WriteLine("No such file");
        WriteLine("For help, use the command: dotnet run -help");
    }
}
else if (args[1] == "--u")
{
    WriteLine("Handling...");
    try
    {
        CompressHandler.Decompress(args[0]);
        WriteLine("\nDone");
    }
    catch (FileNotFoundException)
    {
        WriteLine("No such file");
        WriteLine("For help, use the command: dotnet run -help");
    }
}
else
{
    WriteLine("Second argument isn`t correct !");
    WriteLine("For help, use the command: dotnet run -help");
}

return 0;