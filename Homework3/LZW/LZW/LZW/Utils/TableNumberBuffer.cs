namespace LZW.Utils;


internal class TableNumberBuffer
{
    public List<int> Numbers { get; private set; } = new();

    public int CurrentNumberBitCount { get; set; } = 9;

    public static readonly int BITS_IN_BYTE = 8;
    private int currentNumber = 0;
    private int currentNumberLength = 0;

    public bool AddByte(byte oneByte, bool isLast)
    {
        var newNumber = false;
        var bits = isLast ? BitsOfLastByte(oneByte) : BitsOfByte(oneByte);
        foreach (var bit in bits)
        {
            currentNumber = (currentNumber << 1) + bit;
            if (++currentNumberLength == CurrentNumberBitCount)
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
        List<byte> bites = new();
        while (oneByte > 0)
        {
            bites.Add((byte)(oneByte % 2));
            oneByte >>= 1;
        }

        while (bites.Count + currentNumberLength < CurrentNumberBitCount)
        {
            bites.Add(0);
        }

        bites.Reverse();
        return bites.ToArray();
    }
}