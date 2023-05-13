namespace LZW.Tests;

internal class TableNumberBufferTests
{
    private TableNumberBuffer buffer;

    [SetUp]
    public void Setup()
    {
        buffer = new TableNumberBuffer();
    }

    [Test]
    public void AddTwoNotLastBytes_ShouldAddOnlyOneNumber()
    {
        var expected = new List<int>() { 2 };
        buffer.AddByte(1, false);
        buffer.AddByte(2, false);

        var actual = buffer.Numbers;

        Assert.That(expected.SequenceEqual(actual),Is.True);
    }

    [Test]
    public void AddOneLastByte_NumberShouldBeThisByte()
    {
        var expected = new List<int>() {111};
        buffer.AddByte(111, true);

        var actual = buffer.Numbers;

        Assert.That(expected.SequenceEqual(actual),Is.True);
    }

    [Test]
    public void AddSomeNotLastBytesAndOneLastByte_ShouldReturnTrueNumbers()
    {
        var expected = new List<int>() { 0, 4, 16, 51};
        for (byte i = 0; i < 4; ++i)
        {
            buffer.AddByte(i, false);
        }
        buffer.AddByte((byte)3, true);

        var actual = buffer.Numbers;

        Assert.That(expected.SequenceEqual(actual), Is.True);
    }
}
