namespace LZW.Utils;

internal class TableNumberBuffer
{
    public static readonly int BITS_IN_BYTE = 8;
    public List<uint> Numbers { get; private set; } = new List<uint>();
    public uint CurrentNumberBitCount { get; set; } = 9;
    private uint currentNumber = 0;
    private uint currentNumberLength = 0;

    public bool Add(byte oneByte, bool isLast)
    {
        bool newNumber = false;
        byte[] bits = isLast ? BitsOfByteWithZeros(oneByte) : BitsOfByte(oneByte);
        foreach (byte bit in bits)
        {
            currentNumber = (currentNumber << 1) + bit;
            currentNumberLength++;
            if (currentNumberLength == CurrentNumberBitCount)
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
        byte[] bites = new byte[BITS_IN_BYTE];
        for (int i = BITS_IN_BYTE - 1; i >= 0; --i)
        {
            bites[i] = (byte)(oneByte % 2);
            oneByte >>= 1;
        }

        return bites;
    }

    private byte[] BitsOfByteWithZeros(byte oneByte)
    {
        List<byte> bites = new List<byte>();
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
