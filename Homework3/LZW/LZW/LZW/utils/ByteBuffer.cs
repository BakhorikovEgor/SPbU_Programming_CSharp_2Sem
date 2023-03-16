namespace LZW.Utils;

internal class ByteBuffer
{
    static private readonly byte BITS_IN_BITE = 8;
    public List<byte> Bytes { get; private set; }
    public uint CurrentNumberBitLength {get; set; }
    private byte currentByte;
    private uint currentByteLength;

    public ByteBuffer()
    {
        CurrentNumberBitLength = 9;
        Bytes = new List<byte>();
        currentByte = 0;
        currentByteLength = 0;
    }

    public void Add(uint number)
    {
        byte[] bits = BitsOfUint(number);

        int pointer = 0;
        while (currentByteLength < BITS_IN_BITE)
        {
            currentByte = (byte) ((currentByte << 1) + bits[pointer++]);
            currentByteLength++;
        }

        if (currentByteLength == BITS_IN_BITE)
        {
            AddToBufer();
            Add(bits, pointer);
        }
    }

    private void Add(byte[] bits, int pointer)
    {
        while (currentByteLength < BITS_IN_BITE && pointer < bits.Length)
        {
            currentByte = (byte)((currentByte << 1) + bits[pointer++]);
            currentByteLength++;
        }


        if (currentByteLength == BITS_IN_BITE)
        {
            AddToBufer();
            Add(bits, pointer);
        }
    }

    private byte[] BitsOfUint(uint number)
    {
        List<byte> bits = new List<byte>();

        int bitsLength = 0;
        while (number > 0)
        {
            bitsLength++;
            bits.Add((byte)(number % 2));
            number >>= 1;
        }
        
        for (int i = 0; i < CurrentNumberBitLength - bitsLength; ++i)
        {
            bits.Add(0);
        }

        bits.Reverse();
        return bits.ToArray();
    }

    public void AddToBufer()
    {
        Bytes.Add(currentByte);
        currentByte = 0;
        currentByteLength = 0;
    }

}
