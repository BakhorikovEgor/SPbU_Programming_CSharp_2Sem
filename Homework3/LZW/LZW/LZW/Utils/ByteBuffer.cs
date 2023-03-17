namespace LZW.Utils;


internal class ByteBuffer
{
    public List<byte> Bytes { get; private set; } = new ();

    public int NumberBitLength { get; set; } = 9;

    public byte CurrentByte { get; private set; } = 0;

    static private readonly byte BITS_IN_BYTE = 8;
    private int currentByteLength = 0;

    public void SetBWTPosition(int position)
    {
        Bytes.Add(0);
        var positionBytes = BitConverter.GetBytes(position);
        Bytes.AddRange(positionBytes);
    }
    public void AddNumber(int number)
    {
        var bits = BitsOfUint(number);
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

    public void AddByteToBuffer()
    {
        Bytes.Add(CurrentByte);
        CurrentByte = 0;
        currentByteLength = 0;
    }

    private byte[] BitsOfUint(int number)
    {
        List<byte> bits = new();

        var bitsLength = 0;
        while (number > 0)
        {
            bitsLength++;
            bits.Add((byte)(number % 2));
            number >>= 1;
        }

        for (var i = 0; i < NumberBitLength - bitsLength; ++i)
        {
            bits.Add(0);
        }

        bits.Reverse();
        return bits.ToArray();
    }
}