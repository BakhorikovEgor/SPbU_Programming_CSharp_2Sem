namespace ByteCompressorTest;

public class Tests
{
    private static readonly double _delta = 0.001;
    private static bool AreDoubleEqual(double a, double b)
        => Math.Abs(a - b) <= _delta;


    [TestCase(new byte[] { 0, 1, 2, 3, 4, 5 }, new byte[] {1, 0, 1, 1, 1, 2, 1, 3, 1, 4, 1, 5}, 0.5)]
    [TestCase(new byte[] { 0, 0, 1, 1, 2, 2, 3}, new byte[] {2, 0, 2, 1, 2, 2, 1, 3}, 0.875 )]
    public void CompressWithCorrectData_ShouldReturnExpectedBytesAndRation(byte[] data, byte[] expectedBytes, double expectedRatio)
    {
        (var actualBytes, var actualRation) = Compressor.Compress(data);

        Assert.That(actualBytes.SequenceEqual(expectedBytes), Is.True);
        Assert.That(AreDoubleEqual(actualRation, expectedRatio), Is.True);
    }

    [Test]
    public void CompressWithManyRepeats_ShouldReturnCorrectBytes()
    {
        var data = Enumerable.Repeat((byte)2, 256).ToArray();
        var expectedBytes = new byte[] { 255, 2, 1, 2 };

        var actualBytes = Compressor.Compress(data).Item1;

        Assert.That(actualBytes.SequenceEqual(expectedBytes), Is.True);
    }

    [Test]
    public void CompressEmptyBytes_ShouldThrowExeption()
        => Assert.Throws<InvalidDataException>(() => Compressor.Compress(new byte[] {}));


    [TestCase(new byte[] {1, 0, 1, 1, 1, 2}, new byte[] { 0, 1 ,2})]
    [TestCase(new byte[] {2, 3, 4, 8}, new byte[] { 3, 3, 8, 8, 8, 8})]
    public void DecompressWithCorrectData_ShouldReturnExpectedBytes(byte[] data, byte[] expectedBytes)
        => Assert.That(Compressor.Decompress(data).SequenceEqual(expectedBytes), Is.True);
}