using static System.Console;
using Routers;

if (args.Length < 2)
{
    WriteLine("You should write two path (input and output files)");
}

if (!File.Exists(args[0]) || !File.Exists(args[1]))
{
    WriteLine("You entered not existing file !.");
}

