namespace LZW.Utils;

internal class ByteBuffer
{
    static private readonly byte BITS_IN_BYTE = 8;
    public List<byte> Bytes { get; private set; } = new List<byte>();
    public uint NumberBitLength { get; set; } = 9;
    public byte CurrentByte { get; private set; } = 0;
    private uint currentByteLength = 0;
     

    public void AddToEncode(uint number)
    {
        byte[] bits = BitsOfUint(number);
        for (int i = 0; i < bits.Length; ++i)
        {
            CurrentByte = (byte)((CurrentByte << 1) + bits[i]);
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
        
        for (int i = 0; i < NumberBitLength - bitsLength; ++i)
        {
            bits.Add(0);
        }

        bits.Reverse();
        return bits.ToArray();
    }

}
