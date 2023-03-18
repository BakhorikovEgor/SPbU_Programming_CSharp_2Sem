using LZW.Utils;

namespace LZW;

/// <summary>
/// Allows you to compress and decompress files using the LZW algorithm.
/// </summary>
public static class CompressHandler
{
    /// <summary>
    /// Compresses a file using BWT and without.
    /// Writes a file compression variant using BWT.
    /// </summary>
    /// <param name="path"> File to compress path. </param>
    /// <exception cref="FileNotFoundException"> Throws if file doesn`t exist. </exception>
    internal static void CompressWithAndWithoutBWT(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File doesn`t exist");
        }

        var inputFileBytes = File.ReadAllBytes(path);
        (var bytesBWT, var positionBWT) = BWT.DirectTransformation(inputFileBytes);

        var compressedInputBytes = Compressor.Compress(inputFileBytes);
        var compressedBWTBytes = Compressor.Compress(bytesBWT, positionBWT);

        var compressedFilePath = path + ".zipped";

        File.Create(compressedFilePath).Close();
        File.WriteAllBytes(compressedFilePath, compressedBWTBytes);
        File.Delete(path);

        Console.WriteLine("Compression ratio without BWT: " + ((double)inputFileBytes.Length / compressedInputBytes.Length));
        Console.WriteLine("Compression ratio with BWT: " + ((double)inputFileBytes.Length / compressedBWTBytes.Length));

    }

    /// <summary>
    /// Compresses the file using BWT and writes it to a new one.
    /// </summary>
    /// <param name="path"> File to compress path. </param>
    /// <exception cref="FileNotFoundException"> Throws if file doesn`t exist. </exception>
    public static void Compress(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File doesn`t exist");
        }

        var inputFileBytes = File.ReadAllBytes(path);
        (var bytesBWT, var positionBWT) = BWT.DirectTransformation(inputFileBytes);

        var compressedBWTBytes = Compressor.Compress(bytesBWT, positionBWT);
        var compressedFilePath = path + ".zipped";

        File.Create(compressedFilePath).Close();
        File.WriteAllBytes(compressedFilePath, compressedBWTBytes);
        File.Delete(path);

        Console.WriteLine("Compression ratio with BWT: " + ((double)inputFileBytes.Length / compressedBWTBytes.Length));
    }

    /// <summary>
    /// Decompresses the compressed file.
    /// </summary>
    /// <param name="path"> File to compress path. </param>
    /// <exception cref="FileNotFoundException"> Throws if file doesn`t exist. </exception>
    public static void Decompress(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File doesn`t exist");
        }

        var compressedFileBytes = File.ReadAllBytes(path);

        (var decompressedBytes, var positionBWT) = Decompressor.Decompress(compressedFileBytes);
        if (positionBWT != -1)
        {
            decompressedBytes = BWT.ReverseTransformation(decompressedBytes, positionBWT);
        }

        var decompressedFilePath = path.Replace(".zipped", "");

        File.Create(decompressedFilePath).Close();
        File.WriteAllBytes(decompressedFilePath, decompressedBytes);
        File.Delete(path);
    }
}
