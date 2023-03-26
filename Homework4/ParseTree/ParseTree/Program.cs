using ParsingTree;
using static System.Console;

WriteLine("""
    Hello this is parsing tree program !
    You can write file path with expression,
    this program will show you tree representation of expression
    and calculate it.
    """);

var processing = true;

while (processing)
{
    var pathChecking = true;
    string expression = "";
    while (pathChecking)
    {
        WriteLine("\nEnter file location");
        string? path = ReadLine();
        if (path == null || !File.Exists(path))
        {
            WriteLine("No such file");
            continue;
        }

        expression = File.ReadAllText(path);
        pathChecking = false;
    }

    try
    {
        var parsingTree = new Tree(expression);
        WriteLine($"\nRepresentation: {parsingTree}");
        WriteLine($"\nExpression value: {parsingTree.Calculate()}");
    }
    catch (Exception ex) when (ex is InvalidDataException ||
                               ex is ArgumentException ||
                               ex is DivideByZeroException)
    {
        WriteLine(ex.Message);
    }

    Write("\nWrite 0 to exit: ");
    if (int.TryParse(ReadLine(), out var value) && value == 0)
    {
        processing = false;
    }
}