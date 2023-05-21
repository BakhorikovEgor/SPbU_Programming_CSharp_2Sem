using Routers;
using static System.Console;

if (args[0] == "-help")
{
    WriteLine("""
        This program is for generating the optimal configuration of routers for a given network topology.

        How to use:
        - - - - - - - - - - - - - - - - - - - - - - - - 
        dotnet run [input file path] [output file path]
        (If the path contains spaces -> enclose it in quotes)
        - - - - - - - - - - - - - - - - - - - - - - - - 

        Input file format:
        - - - - - - - - - - - - - - - - - - - - - - - - 
        routerNumber: linkedRouterNumber (throughput), etc....
        - - - - - - - - - - - - - - - - - - - - - - - - 

        """);

    return 0;
}

if (args.Length < 2)
{
    WriteLine("Two arguments are needed.");
    WriteLine("For help, use the command: dotnet run -help");
    return 0;
}

if (!File.Exists(args[0]) || !File.Exists(args[1]))
{
    WriteLine("You entered not existing file.");
    WriteLine("For help, use the command: dotnet run -help");
    return 0;
}

var topology = File.ReadAllText(args[0]);

try
{
    var configuration = ConfigurationBuilder.BuildConfiguration(topology);
    File.WriteAllText(args[1], configuration);

    WriteLine("Done");
}
catch (TopologyNotConnectedException ex)
{
    Error.WriteLine(ex.Message);
    WriteLine("For help, use the command: dotnet run -help");
    return 1;
}
catch (Exception ex) when (ex is FormatException ||
                           ex is ArgumentException)
{
    WriteLine(ex.Message);
    WriteLine("For help, use the command: dotnet run -help");
}

return 0;

