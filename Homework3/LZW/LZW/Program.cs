using LZW;
using LZW.Utils;

string path;

if (args.Length < 2)
{
    throw new IOException("Less than 2 arguments");
}

else
{
    path = args[0];

    if (!File.Exists(path))
    {
        throw new FileNotFoundException("File doesn`t exist");
    }
    else if (args[1] == "-c")
    {
        var inputFileBytes = File.ReadAllBytes(path);
        (var bytesBWT, var positionBWT) = BWT.DirectTransformation(inputFileBytes);

        var compressedInputBytes  = Compressor.Compress(inputFileBytes);
        var compressedBWTBytes  = Compressor.Compress(bytesBWT, positionBWT);

        var pathParts = path.Split(".");
        var compressedFilePath = pathParts[0] +  "." + pathParts[1] + ".zipped";

        File.Create(compressedFilePath).Close();
        File.WriteAllBytes(compressedFilePath, compressedBWTBytes);

        Console.WriteLine("Compression ratio without BWT: " + (double)inputFileBytes.Length / compressedInputBytes.Length);
        Console.WriteLine("Compression ratio with BWT: " + (double)inputFileBytes.Length / compressedBWTBytes.Length);

    }
    else if (args[1] == "-u")
    {
        var compressedFileBytes = File.ReadAllBytes(path);

        (var decompressedBytes, var positionBWT) = Decompressor.Decompress(compressedFileBytes);
        if (positionBWT != -1)
        {
            decompressedBytes = BWT.ReverseTransformation(decompressedBytes, positionBWT);
        }

        var pathParts = path.Split('.');
        string decompressedFilePath = pathParts[0] + "Updated" + "." + pathParts[1];

        File.Create(decompressedFilePath).Close();
        File.WriteAllBytes(decompressedFilePath, decompressedBytes);
    }

}