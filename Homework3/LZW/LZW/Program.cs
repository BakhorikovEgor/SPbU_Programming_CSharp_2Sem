using LZW;


if (args.Length < 2)
{
    throw new IOException("Less than 2 arguments");
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
    throw new IOException("Second argument isn`t correct !");
}