namespace LZW.Utils;

/// <summary>
/// Byte buffer, for generating byte sequences of variable length.
/// </summary>
internal class ByteBuffer
{
    /// <summary>
    /// The generated sequence of bytes.
    /// </summary>
    public List<byte> Bytes { get; private set; } = new ();

    /// <summary>
    /// The length of the current, stored byte.
    /// </summary>
    public int CurrentBitLength { get; set; } = 9;

    /// <summary>
    /// The byte currently being generated.
    /// </summary>
    public byte CurrentByte { get; private set; } = 0;

    static private readonly byte BITS_IN_BYTE = 8;
    private int currentByteLength = 0;

    /// <summary>
    /// Add the first four bytes, to further determine
    /// the position of the byte, for the reverse BWT.
    /// </summary>
    /// <param name="position"> Position to do reverse BWT. </param>
    public void SetBWTPosition(int position)
    {
        var positionBytes = BitConverter.GetBytes(position);
        Bytes.AddRange(positionBytes);
    }

    /// <summary>
    /// Add a number to the byte stream.
    /// </summary>
    /// <param name="number"> Number to add. </param>
    public void AddNumber(int number)
    {
        var bits = BitsOfInt(number);
        foreach(var bit in bits)
        {
            CurrentByte = (byte)((CurrentByte << 1) + bit);
            currentByteLength++;
            if (currentByteLength == BITS_IN_BYTE)
            {
                AddByteToBuffer();
            }
        }
    }

    /// <summary>
    /// Add the current byte to the byte stream.
    /// </summary>
    public void AddByteToBuffer()
    {
        Bytes.Add(CurrentByte);
        CurrentByte = 0;
        currentByteLength = 0;
    }

    private byte[] BitsOfInt(int number)
    {
        var bits = new byte[CurrentBitLength];
        for (var i = CurrentBitLength - 1; i >= 0; i--)
        {
            bits[i] = (byte)(number % 2);
            number >>= 1;
        }

        return bits;
    }
}