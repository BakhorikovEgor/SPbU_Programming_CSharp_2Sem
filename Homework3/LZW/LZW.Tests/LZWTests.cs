namespace LZW.Tests;

public class Tests
{

    [TestCase("../../../../LZW/TestFiles/video.mp4")]
    [TestCase("../../../../LZW/TestFiles/Tic_Tac_Toe.exe")]
    [TestCase("../../../../LZW/TestFiles/pdf.pdf")]
    [TestCase("../../../../LZW/TestFiles/WarAndPeace.txt")]
    public void CompressAndDecompress_ShouldNotChangeTheFile(string path)
    {
        var expected = File.ReadAllBytes(path);
        CompressHandler.Compress(path);
        CompressHandler.Decompress(path + ".zipped");

        var actual = File.ReadAllBytes(path);

        Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));

    }

    [TestCase("../../../../LZW/TestFiles/empty")]
    public void CompressEmptyFile_ShouldThrowException(string path)
    {
        Assert.Throws<ArgumentException>(() => CompressHandler.Compress(path));
    }

    [TestCase("../../../../LZW/TestFiles/empty")]
    public void DecompressEmptyFile_ShouldThrowException(string path)
    {
        Assert.Throws<ArgumentException>(() => CompressHandler.Decompress(path));
    }

    [TestCase("../../../../LZW/TestFiles/source2.exe")]
    public void CompressNotExistingFile_ShouldThrowException(string path)
    {
        Assert.Throws<FileNotFoundException>(() => CompressHandler.Compress(path));
    }

    [TestCase("../../../../LZW/TestFiles/source2.exe")]
    public void DecompressNotExistingFile_ShouldThrowException(string path)
    {
        Assert.Throws<FileNotFoundException>(() => CompressHandler.Decompress(path));
    }
}