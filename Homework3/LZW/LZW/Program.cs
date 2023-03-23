using LZW;


if (args.Length < 2)
{
    Console.WriteLine("Less than 2 arguments");
}
else if (args[1] == "-c")
{
    CompressHandler.CompressWithAndWithoutBWT(args[0]);
}
else if (args[1] == "-u")
{
    CompressHandler.Decompress(args[0]);
}
else
{
    Console.WriteLine("Second argument isn`t correct !");
}