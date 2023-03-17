namespace LZW.Utils;


/// <summary>
/// A buffer for generating from a byte sequence,
/// key numbers of the table for decompressing information.
/// </summary>
internal class TableNumberBuffer
{
    /// <summary>
    /// The generated key numbers of decompression table.
    /// </summary>
    public List<int> Numbers { get; private set; } = new();

    /// <summary>
    /// The length of bits to read, before converting to number.
    /// </summary>
    public int CurrentBitCount { get; set; } = 9;

    public static readonly int BITS_IN_BYTE = 8;

    private int currentNumber = 0;
    private int currentNumberLength = 0;

    /// <summary>
    /// Add to the current number, a new byte, before filling.
    /// </summary>
    /// <param name="oneByte"> Byte to add. </param>
    /// <param name="isLast"> If this byte is the last in streaming sequence, than add additional zeros.</param>
    /// <returns> Has a new number been added. </returns>
    public bool AddByte(byte oneByte, bool isLast)
    {
        var newNumber = false;
        var bits = isLast ? BitsOfLastByte(oneByte) : BitsOfByte(oneByte);
        foreach (var bit in bits)
        {
            currentNumber = (currentNumber << 1) + bit;
            if (++currentNumberLength == CurrentBitCount)
            {
                AddToBuffer();
                newNumber = true;
            }
        }

        return newNumber;
    }

    private void AddToBuffer()
    {
        Numbers.Add(currentNumber);
        currentNumber = 0;
        currentNumberLength = 0;
    }

    private byte[] BitsOfByte(byte oneByte)
    {
        var bites = new byte[BITS_IN_BYTE];
        for (var i = BITS_IN_BYTE - 1; i >= 0; --i)
        {
            bites[i] = (byte)(oneByte % 2);
            oneByte >>= 1;
        }

        return bites;
    }

    private byte[] BitsOfLastByte(byte oneByte)
    {
        var bites = new List<byte>();
        while (oneByte > 0)
        {
            bites.Add((byte)(oneByte % 2));
            oneByte >>= 1;
        }

        while (bites.Count + currentNumberLength < CurrentBitCount)
        {
            bites.Add(0);
        }

        bites.Reverse();
        return bites.ToArray();
    }
}