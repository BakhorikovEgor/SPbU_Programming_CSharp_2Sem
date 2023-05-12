namespace LZW.Tests;

internal class ByteBufferTests
{
    private ByteBuffer buffer;

    [SetUp]
    public void Setup()
    {
        buffer = new ByteBuffer();
    }

    [Test]
    public void AddNumbersToBufferAndGetBytesWithoutRemainder_ShouldReturnTrueBytes()
    {
        var expected = new byte[] { 0, 0, 64, 64, 48 };
        for (int i = 0; i < 5; ++i)
        {
            buffer.AddNumber(i);
        }

        var actual = buffer.Bytes;

        Assert.That(expected.SequenceEqual(actual), Is.True);
    }

    [Test]
    public void AddNumbersToBufferAndCheckRemainder_ShouldReturnTrueRemainder()
    {
        var expected = 4;
        for (int i = 0; i < 5; ++i)
        {
            buffer.AddNumber(i);
        }

        var actual = buffer.CurrentByte;

        Assert.That(expected.Equals(actual), Is.True);
    }

    [Test]
    public void AddOneNumberAndAddRemainderToBufferCheckBytes_ShouldReturnTrueBytes()
    {
        var expected = new byte[] { 5, 0 };
        buffer.AddNumber(10);
        buffer.AddByteToBuffer();

        var actual = buffer.Bytes;

        Assert.That(expected.SequenceEqual(actual), Is.True);
    }


}
